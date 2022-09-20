//Global Variables

var MyRetcode;
var z=0;
var y=0;
var ValidateStatus;
var chkpopup;
var mod;
var show="0";
var show1="0";
var codeid;
var hiddentext;
var cityvar;
var regionvar='';
//var taluka1='';
var flag2="0";
var chknamemod;
var modify="0";

var updatecommission;
var distcode;

var flag21="";
var statecode;
var zonecode;
var regioncode;
//global declarations.....873


var dsforexecute;//global data set ....


var glpubcent;
var glretaincode;
var glretainname;
var glalias;
var gladd;
var glstreet
var glcity;
var glpin;
var gldist;
var glstate;
var glzone;
var glcountry;
var glfax;
var glphone;
var glemail;
var glpan;
var glbox;
var saurabh="1";
var  glcreditdays;
var  glstatus;
var  glstatusdate;
var  glremark;
var hiddentext;
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
  //  RetCancelClick('RetainerMaster');
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


function RetNewClick()
{
 var msg=checkSession();
        if(msg==false)
        return false;
hiddentext="New";
flag21="N"
document.getElementById('hiddenchk').value="0";
show="1";
saurabh="1";
flag2="0";
modify="0";

document.getElementById('hiddensaurabh').value="1";
	
				 if(document.getElementById('hiddenauto').value==1)
		         {
		         document.getElementById('txtretainercode').disabled=true;
		         document.getElementById('txtretainername').disabled=false;
		         document.getElementById('txtretainername').focus();
    	         }
		        else
		         {
		          document.getElementById('txtretainercode').disabled=false;
		          document.getElementById('txtretainercode').focus();
    	         }
	
	
	
	
//	document.getElementById('txtstatus1').style.visibility = "hidden";
//	document.getElementById('txtstatusdate').style.visibility = "hidden";
//	document.getElementById('Label31').style.visibility="hidden";
//	document.getElementById('Label23').style.visibility="hidden";

    //document.getElementById('Label23').style.visibility="Block";
    
//	document.getElementById('txtstatus1').style.visibility = "none";
//	document.getElementById('txtstatusdate').style.visibility = "none";
//	document.getElementById('Label31').style.visibility="none";
//	document.getElementById('Label23').style.visibility="none";


    document.getElementById('trstatus').style.display="none";

	//document.getElementById('txtretainercode').disabled=false;			
	document.getElementById('txtretainername').disabled=false;			
	document.getElementById('txtalias').disabled=false;		
	document.getElementById('txtadd1').disabled=false;					
	document.getElementById('txtstreet').disabled=false;			
	document.getElementById('drppubcent').disabled=false;
	
	document.getElementById('drpPName').disabled=false;		
	
	
//	document.getElementById('drpPName').focus();	
	document.getElementById('txtcreditlimit').disabled=false;	
	document.getElementById('drpcity').disabled=false;	
	document.getElementById('drptaluka').disabled=false;				
	document.getElementById('txtdistrict').disabled=false;				
	document.getElementById('txtcountry').disabled=false;					
	document.getElementById('txtphone1').disabled=false;			
	document.getElementById('txtphone2').disabled=false;
	document.getElementById('txtmobile').disabled=false;			
	document.getElementById('txtemailid').disabled=false;		
	document.getElementById('txtPan').disabled=false;	
	document.getElementById('txtcreditdays').disabled=false;					
	document.getElementById('txtremarks').disabled=false;			
	document.getElementById('txtpincode').disabled=false;					
	document.getElementById('txtstate').disabled=false;	
	document.getElementById('drpzone').disabled=false;	
	document.getElementById('drpregion').disabled=false;	
	//document.getElementById('txtstate').disabled=false;			
	document.getElementById('txtfax').disabled=false;	
	document.getElementById('txtrepname').disabled=false;	
	document.getElementById('drpbranch').disabled=false;	
	document.getElementById('drpEdition').disabled=false;					
	document.getElementById('drpSuppliment').disabled=false;
	document.getElementById('txtemcode').disabled = false;
	document.getElementById('txtemcode').value = "";
	document.getElementById('drpgstus').disabled = false;
	document.getElementById('txtgstdt').disabled = false;
	document.getElementById('txtgstin').disabled = false;
	document.getElementById('txtgstclty').disabled = false;
	document.getElementById('drpgstatus').disabled = false;


	document.getElementById('drpgstus').value = "Y";
	document.getElementById('txtgstdt').value = "";
	document.getElementById('txtgstin').value = "";
	document.getElementById('txtgstclty').value = "";
	document.getElementById('drpgstatus').value = "Y";
	document.getElementById('hdngstclty').value = "";
	
	
	document.getElementById('txtmaincdp').disabled = false;
	document.getElementById('txtmaincdp').value = "";
	document.getElementById('txtmaincds').disabled = true;
	document.getElementById('txtmaincds').value = "";
	document.getElementById('txtcontact').disabled = false;
	document.getElementById('txtoldcod').disabled = false;
	document.getElementById('txtaccod').disabled = false;
	document.getElementById('drpgstus').disabled = false;
	document.getElementById('txtgstdt').disabled = false;
	document.getElementById('txtgstin').disabled = false;
	document.getElementById('txtgstclty').disabled = false;
	document.getElementById('drpgstatus').disabled = false;
	document.getElementById('txtbox').disabled=false;		

	document.getElementById('txtretainercode').value="";
	document.getElementById('txtretainername').value="";			
	document.getElementById('txtalias').value="";		
	document.getElementById('txtadd1').value="";					
	document.getElementById('txtstreet').value="";			
	document.getElementById('drpcity').value="0";	
	document.getElementById('drppubcent').value="0";	
			
	document.getElementById('txtdistrict').value="";				
	document.getElementById('txtcountry').value="0";					
	document.getElementById('txtphone1').value="";			
	document.getElementById('txtphone2').value="";
	document.getElementById('txtmobile').value="";			
	document.getElementById('txtemailid').value="";		
	document.getElementById('txtPan').value="";	
	document.getElementById('txtcreditdays').value="";					
	document.getElementById('txtpincode').value="";					
	document.getElementById('txtstate').value="";	
	document.getElementById('drpzone').value="0";	
	document.getElementById('drpregion').value="0";	
	document.getElementById('txtfax').value="";
	document.getElementById('drpbranch').value="0";
	document.getElementById('txtbox').value="";
	
	
	
	document.getElementById('drpPName').value="0";	
	document.getElementById('drpEdition').value="0";	
	document.getElementById('drpSuppliment').value="0";	
    document.getElementById('txtrepname').value="0";
    document.getElementById('txtsign').value="";
    document.getElementById('txtoldcod').value="";
	document.getElementById('txtaccod').value="";	
	document.getElementById('drpgstus').value = "Y";
	document.getElementById('txtgstdt').value = "";
	document.getElementById('txtgstin').value = "";
	document.getElementById('txtgstclty').value = "";
	document.getElementById('drpgstatus').value = "Y";
	document.getElementById('hdngstclty').value = "";
	 document.getElementById('lbtnStatusDetail').disabled=false;	
     document.getElementById('lbtnClientPaymode').disabled=false;	
     document.getElementById('lbcommdetail').disabled=false;
     document.getElementById('lblretcomslab').disabled = false;
    // document.getElementById('creaditslab').disabled = false;
     
		document.getElementById('lblsign').disabled=false;
	 document.getElementById('attachment1').disabled = false;
	document.getElementById('drpcity').options.length=0;
	document.getElementById('drpcity').options[0] = new Option("--Select City--", "0");
	
	
	
				
	//document.Form1.txtretainercode.focus();
	
/*	if(document.getElementById('hiddenauto').value==1)
				{
				
				  document.getElementById('txtretainername').focus();
			    } 
			    else
			    {
			    document.getElementById('txtretainercode').focus();
				}*/
				
	//hiddentext="new";
	
	chkstatus(FlagStatus);
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	//alert(show);
	setButtonImages();
	return false;		
}


var  Retcodefordelete;
function RetCancelClick(formname) 
{
     var msg=checkSession();
    if(msg==false)
    return false;
    
    document.getElementById('hiddensubmod').value="0";
    document.getElementById('hiddensubmod').value="0";
    document.getElementById('hiddensaurabh').value="0";
    flag2="0";
    modify="0";

   dsforexecute=null;
 
   show="0";

	
	document.getElementById('trstatus').style.display="none";
	var compcode=document.getElementById('hiddencompcode').value;
	Retcodefordelete=document.getElementById('txtretainercode').value;
	var userid=document.getElementById('hiddenuserid').value;
	document.getElementById('txtcreditlimit').disabled=true;
	document.getElementById('btnSave').disabled = true;
	document.getElementById('txtretainercode').disabled=true;			
	document.getElementById('txtretainername').disabled=true;			
	document.getElementById('txtalias').disabled=true;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=true;			
	document.getElementById('txtdistrict').disabled=true;
	document.getElementById('drppubcent').disabled=true;				
	document.getElementById('txtcountry').disabled=true;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;
	document.getElementById('txtmobile').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;
	document.getElementById('drpzone').disabled=true;
	document.getElementById('drptaluka').disabled=true;
	document.getElementById('drpregion').disabled=true;
	document.getElementById('txtfax').disabled=true;			
    document.getElementById('drpPName').disabled=true;
	document.getElementById('drpEdition').disabled=true;
	document.getElementById('drpSuppliment').disabled=true;
	document.getElementById('txtrepname').disabled=true;
	document.getElementById('drpbranch').disabled=true;
	document.getElementById('txtremarks').disabled = true;
	document.getElementById('txtemcode').disabled = true;
    document.getElementById('txtmaincdp').disabled = true;
	document.getElementById('txtmaincds').disabled = true;
	document.getElementById('txtcontact').disabled = true;
    document.getElementById('txtoldcod').disabled = true;
    document.getElementById('txtaccod').disabled = true;
    document.getElementById('drpgstus').disabled = true;
    document.getElementById('txtgstdt').disabled = true;
    document.getElementById('txtgstin').disabled = true;
    document.getElementById('txtgstclty').disabled = true;
    document.getElementById('drpgstatus').disabled = true;

   // document.getElementById('creaditslab').disabled = true;
    document.getElementById('drpgstus').disabled = true;
    document.getElementById('txtgstdt').disabled = true;
    document.getElementById('txtgstin').disabled = true;
    document.getElementById('txtgstclty').disabled = true;
    document.getElementById('drpgstatus').disabled = true;

     document.getElementById('txtmaincdp').value = "";		
	document.getElementById('txtmaincds').value="";
	document.getElementById('txtemcode').value = "";

	document.getElementById('drpgstus').value = "Y";
	document.getElementById('txtgstdt').value = "";
	document.getElementById('txtgstin').value = "";
	document.getElementById('txtgstclty').value = "";
	document.getElementById('drpgstatus').value = "Y";
	document.getElementById('hdngstclty').value = "";
	document.getElementById('txtretainercode').value="";
	document.getElementById('txtretainername').value="";			
	document.getElementById('txtalias').value="";	
	 document.getElementById('txtrepname').value="0";		
	document.getElementById('txtadd1').value="";					
	document.getElementById('txtstreet').value="";			
	document.getElementById('drpcity').value=0;			
	document.getElementById('txtdistrict').value="";				
	document.getElementById('txtcountry').value="0";
    document.getElementById('drppubcent').value="0";
    document.getElementById('drptaluka').value="0";					
	document.getElementById('txtphone1').value="";			
	document.getElementById('txtphone2').value="";
	document.getElementById('txtmobile').value="";				
	document.getElementById('txtemailid').value="";		
	document.getElementById('txtPan').value="";	
	document.getElementById('txtcreditdays').value="";					
	document.getElementById('txtpincode').value="";					
	document.getElementById('txtstate').value="";			
	document.getElementById('drpzone').value="0";
				document.getElementById('drpregion').value="0";
	document.getElementById('txtfax').value="";		
	document.getElementById('txtremarks').value="";		
	document.getElementById('txtrepname').value="0";
	document.getElementById('txtbox').value="";	
	document.getElementById('drpbranch').value="0";
		document.getElementById('txtcreditlimit').value="";
	document.getElementById('drpPName').value="0";
	document.getElementById('drpEdition').value="0";
	document.getElementById('drpSuppliment').value="0";
	document.getElementById('drpcity').options.length=0;
	document.getElementById('drpcity').options[0]=new Option("--Select City--","0");
    document.getElementById('txtsign').value="";
    
    document.getElementById('txtoldcod').value="";
	document.getElementById('txtaccod').value="";
    document.getElementById('txtcontact').value="";
    document.getElementById('lblsign').disabled = true;
    document.getElementById('drpgstus').value = "Y";
    document.getElementById('txtgstdt').value = "";
    document.getElementById('txtgstin').value = "";
    document.getElementById('txtgstclty').value = "";
    document.getElementById('drpgstatus').value = "Y";
    document.getElementById('hdngstclty').value = "";
	mod="";
	//getPermission(formname);
	
	
	           /* document.getElementById('btnNew').disabled=false;
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
				document.getElementById('btnExit').disabled=false;*/
				
				 // for making the session null
		            
		            var retcode = document.getElementById('hiddenretcode').value;
		            
		            flag_save="false";
                    flag_null="true";
                     var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false );
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
                                alert('Session Expired.Please Login Again.');
                                return false;
                            }
                        }
                    }
		            else
		            {
		            var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false );
		            xml.Send();
		            var dl=xml.responseText;
		            }
		            flag_save="false";
                    flag_null="false";
                    
                    document.getElementById('lbtnStatusDetail').disabled=true;	
                    document.getElementById('lbtnClientPaymode').disabled=true;	
                    document.getElementById('lbcommdetail').disabled=true;
                    document.getElementById('lblretcomslab').disabled = true;
                    //document.getElementById('creaditslab').disabled = true;
                    
				    givebuttonpermission(formname);
				    setButtonImages();
				    if(document.getElementById('btnNew').disable==false)
                      document.getElementById('btnNew').focus();
				    
	
	return false;		
}

function checkretainerdata_CallBack(response)
{
	var ds = response.value;
	if(ds.Tables[0].Rows.length==0)
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		RetainerMaster.RetainerDelete(compcode,Retcodefordelete,userid);
		return false;
	}
	return false;
}


function RetValidateFields()
{
 var msg=checkSession();
        if(msg==false)
        return false;
    var bc=document.getElementById('Label1').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(document.getElementById('drppubcent').value== "0")
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        document.getElementById('drppubcent').focus();
	            ValidateStatus =0;
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	
	  bc=document.getElementById('Label2').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if((trim(document.getElementById('txtretainercode').value)=="")&&(document.getElementById('hiddenauto').value!=1))
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('txtretainercode').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	    
	  bc=document.getElementById('Label12').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtretainername').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('txtretainername').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	        
	    }
	    
	      bc=document.getElementById('Label5').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtalias').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('txtalias').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	    
	      bc=document.getElementById('Label32').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(document.getElementById('txtcountry').value== "0" || document.getElementById('txtcountry').value== "")
	        {   
		        alert('Please Select '+(bc.replace('*', "")));
		        //ValidateStatus =0;
	            document.getElementById('txtcountry').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	    
	    bc=document.getElementById('Label7').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(document.getElementById('drpcity').value== "0" || document.getElementById('drpcity').value== "")
	        {   
		        alert('Please Select '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('drpcity').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	    
	
	
	
}

function stat()
{   
    alert('Please Fill Status Detail Pop Up');
    return false;
}

function RetSaveClick() 
{
	
	if(modify=="1")
	show="0";
	

	
	
	 var msg=checkSession();
        if(msg==false)
        return false;
             // 
	//RetValidateFields();
//==============================================================================================
//                                  saurabh save code
 var bc="";
if(browser!="Microsoft Internet Explorer")
    {
        
        bc=document.getElementById('Label1').textContent;
         
    }
    else
    {
      
       bc=document.getElementById('Label1').innerHTML;
      
      
    }

    if(bc.indexOf('*')>= 0 )
	    {
	        if(document.getElementById('drppubcent').value== "0")
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        document.getElementById('drppubcent').focus();
	            ValidateStatus =0;
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('Label2').textContent;
                }
                else
                {
                   bc=document.getElementById('Label2').innerText;
                }
	
    if(bc.indexOf('*')>= 0 )
	    {
	        if((trim(document.getElementById('txtretainercode').value)=="")&&(document.getElementById('hiddenauto').value!=1))
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('txtretainercode').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('lblbranch').textContent;
                }
                else
                {
                   bc=document.getElementById('lblbranch').innerText;
                }
	  
    if(bc.indexOf('*')>= 0 )
	    {
	        if(document.getElementById('drpbranch').value== "0" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        ValidateStatus =0;
		        if(document.getElementById('drpbranch').disabled==false)
	            document.getElementById('drpbranch').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	        
	    }
	    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('Label2').textContent;
                }
                else
                {
                   bc=document.getElementById('Label12').innerText;
                }
	  
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtretainername').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('txtretainername').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	        
	    }
	    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('Label5').textContent;
                }
                else
                {
                   bc=document.getElementById('Label5').innerText;
                }
	     
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtalias').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('txtalias').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	     if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('Label32').textContent;
                }
                else
                {
                   bc=document.getElementById('Label32').innerText;
                }
	     
    if(bc.indexOf('*')>= 0 )
	    {
	        if(document.getElementById('txtcountry').value== "0" || document.getElementById('txtcountry').value== "")
	        {   
		        alert('Please Select '+(bc.replace('*', "")));
		        //ValidateStatus =0;
	            document.getElementById('txtcountry').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }
	    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('Label7').textContent;
                }
                else
                {
                   bc=document.getElementById('Label7').innerText;
                }
	     	    
    if(bc.indexOf('*')>= 0 )
	    {
	        if(document.getElementById('drpcity').value== "0" || document.getElementById('drpcity').value== "")
	        {   
		        alert('Please Select '+(bc.replace('*', "")));
		        ValidateStatus =0;
	            document.getElementById('drpcity').focus();
	            return false;
	        }
	        else
	        {ValidateStatus =1;}
	    }


	    if (browser != "Microsoft Internet Explorer") {
	        bc = document.getElementById('lbemcode').textContent;
	    }
	    else {
	        bc = document.getElementById('lbemcode').innerText;
	    }

	    if (bc.indexOf('*') >= 0) {
	        if (trim(document.getElementById('txtemcode').value) == "") {
	            alert('Please Enter ' + (bc.replace('*', "")));
	            ValidateStatus = 0;
	            document.getElementById('txtemcode').focus();
	            return false;
	        }
	        else
	        { ValidateStatus = 1; }

	    }

	    if (document.getElementById('drpgstatus').value == "Y") {
	        var chmandat1 = "";
	        if (browser != "Microsoft Internet Explorer") {
	            chmandat1 = document.getElementById('lblgstclty').textContent;
	        }
	        else {
	            chmandat1 = document.getElementById('lblgstclty').innerText;
	        }
	        if (chmandat1.indexOf('*') >= 0) {
	            if (document.getElementById('txtgstclty').value == "0" || document.getElementById('txtgstclty').value == "") {
	                alert("Please enter the Gst Client Type");
	                document.getElementById('txtgstclty').focus();
	                return false;
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
	            if (document.getElementById('drpgstus').value == "0" || document.getElementById('drpgstus').value == "") {
	                alert("Please enter the Gst Status ");
	                document.getElementById('drpgstus').focus();
	                return false;
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
	            if (document.getElementById('txtgstdt').value == "0" || document.getElementById('txtgstdt').value == "") {
	                alert("Please enter the Gst Registration Date");
	                document.getElementById('txtgstdt').focus();
	                return false;
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
	            if (document.getElementById('txtgstin').value == "0" || document.getElementById('txtgstin').value == "") {
	                alert("Please enter the Gst Registration");
	                document.getElementById('txtgstin').focus();
	                return false;
	            }
	        }
	    }
   
     if (trim(document.getElementById('txtemcode').value) != "" && document.getElementById('hdempcode').value == "") {
	        alert("Please Select Emp Code With F[2]");
	        document.getElementById('txtemcode').focus();
	        return false;
	    }
	    if (browser != "Microsoft Internet Explorer") {
	        bc = document.getElementById('lbmaincdp').textContent;
	    }
	    else {
	        bc = document.getElementById('lbmaincdp').innerText;
	    }
	    if (bc.indexOf('*') >= 0) {
	        if (trim(document.getElementById('txtmaincdp').value) == "") {
	            alert('Please Enter ' + (bc.replace('*', "")));
	            ValidateStatus = 0;
	            document.getElementById('txtmaincdp').focus();
	            return false;
	        }
	        else
	        { ValidateStatus = 1; }

	    }
	    if (trim(document.getElementById('txtmaincdp').value) != "" && document.getElementById('hiddenmaincdp').value=="") {
	        alert("Please Select Main CDP With F[2]");
	        document.getElementById('txtmaincdp').focus();
	        return false;
	    }
   
   
     if (browser != "Microsoft Internet Explorer") {
	        bc = document.getElementById('lbmaincds').textContent;
	    }
	    else {
	        bc = document.getElementById('lbmaincds').innerText;
	    }
	    if (bc.indexOf('*') >= 0) {
	        if (trim(document.getElementById('txtmaincds').value) == "") {
	            alert('Please Enter ' + (bc.replace('*', "")));
	            ValidateStatus = 0;
	            document.getElementById('txtmaincds').focus();
	            return false;
	        }
	        else
	        { ValidateStatus = 1; }

	    }
	    if (trim(document.getElementById('txtmaincds').value) != "" && document.getElementById('hiddenmaincds').value=="") {
	        alert("Please Select Main CDP With F[2]");
	        document.getElementById('txtmaincds').focus();
	        return false;
	    }
//    if(trim(document.getElementById('txtbox').value)== "" )
//	        {   
//		        alert('Please Enter Box Matter');
//		        ValidateStatus =0;
//	            document.getElementById('txtbox').focus();
//	            return false;
//	        }
//	        else
//	        {
//	        {ValidateStatus =1;}
//	        
//	    }
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
//==============================================================================================
	
// code by bhattar
	
	if(ValidateStatus==1)
	{
		if(mod=="modify")
		{
			
			 if(chknamemod==document.getElementById('txtretainername').value)
             {
                RetainerUpdate();
             }
            else
            {
               strname=trim(document.getElementById('txtretainername').value);
               strcode=trim(document.getElementById('txtretainercode').value);
              
               RetainerMaster.chkretainercodemod(strcode,strname,fcall);
              return false; 
            }
		}
		else
		{

            document.getElementById('trstatus').style.display="none";
			var compcode=document.getElementById('hiddencompcode').value;
			var Retcode=document.getElementById('txtretainercode').value;
			var userid2=document.getElementById('hiddenuserid').value;
			var retcode=document.getElementById('txtretainercode').value;
			var repname=document.getElementById('txtrepname').value;
			var signature=document.getElementById('txtsign').value;
			
				var attachment = document.getElementById('attachment1').value;
			var id;
			var empcode = document.getElementById('hdempcode').value;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkret.aspx?retcode="+retcode, false);
                        httpRequest.send('');
                        id = httpRequest.responseText;

                        if (id == "yes") {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }

                        if (id == "NO1") {
                            alert("Please Fill the Status detail Pop Up");
                            return false;
                        }
                        else 
                        if (id == "NO2") {
                            alert("Please Fill the Commission detail Pop Up");
                            return false;
                        }
//                        else if (id == "NO3") {
//                            alert("Please Fill the PayMode detail Pop Up");
//                            return false;
//                        }
//                        else if (id == "NO4") {
//                            alert("Please Fill the Slab detail Pop Up");
//                            return false;
//                        }
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
                                
                            }
                           else 
                            {
                                alert('Session Expired.Please Login Again.');
                                return false;
                            }
                        }
                    }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        xml.Open( "GET","chkret.aspx?retcode="+retcode, false );
		        xml.Send();
		        var dl=xml.responseText;
		       
		      }  
		      if(dl=="yes")
		      {
		          alert('Session Expired.Please Login Again.');
                  return false;
		      }
		          if(dl=="NO2")
		    {
    		     alert("Please Fill the Commission detail Pop Up");
	             return false;
           	}
		          
		   
            else 
             if(dl=="NO1")
		    {
    		     alert("Please Fill the Status detail Pop Up");
	             return false;
           	}
//           	else
//                 if(dl=="NO3")
//		    {
//    		     alert("Please Fill the PayMode detail Pop Up");
//	             return false;
//           	}
//          	else if(dl=="NO4")
//		    {
//    		     alert("Please Fill the Slab detail Pop Up");
//	             return false;
//           	}
        
			/*document.getElementById('btnNew').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;	
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		*/	

			//check whether the user has filled all the popup or not
			
		//	RetainerMaster.checkpopup(compcode,Retcode,userid2,getData_CallBack)
			
			
			
			//saurabh
			//chkstatus(FlagStatus);
			
				
		
			
			
		//CancelClick('RetainerMaster');
		
	//	RetCancelClick('RetainerMaster');
		
//		return false;
			
//			return false;
//		}
//	}
//	return false;
//}


////Function CallBack
//function getData_CallBack(response)
//{
//	var ds = response.value;
//	if(ds.Tables[3].Rows.length > 0)
//	{
//	alert("This Code Has Been Assigned");
//	return false;
//	
//	}
//	
////	else if(ds.Tables[1].Rows.length==0)
////	{
////		alert("Please Enter Status Detail ");	
////		document.getElementById('btnNew').disabled=true;
////		document.getElementById('btnSave').disabled=false;
////		return false;
////	}
////	else if(ds.Tables[0].Rows.length==0)
////	{
////		alert("Please Enter Commission Details ");	
////		document.getElementById('btnNew').disabled=true;
////		document.getElementById('btnSave').disabled=false;
////		return false;
////	}
////	else if(ds.Tables[2].Rows.length==0)
////	{
////		alert("Please Enter Paymode Details ");	
////		document.getElementById('btnNew').disabled=true;
////		document.getElementById('btnSave').disabled=false;
////		return false;
////	}
//	else
//	{
		var compcode=document.getElementById('hiddencompcode').value;
		var Retcode=trim(document.getElementById('txtretainercode').value);
		var retname=trim(document.getElementById('txtretainername').value);
		var alias=trim(document.getElementById('txtalias').value);
		var add1=trim(document.getElementById('txtadd1').value);
		var city=document.getElementById('drpcity').value;
		var repname=document.getElementById('txtrepname').value;
		
		var pubcent=document.getElementById('drppubcent').value;
		var street=trim(document.getElementById('txtstreet').value);
		var country=document.getElementById('txtcountry').value;
		var pincode=document.getElementById('txtpincode').value;
		
		var dist=document.getElementById('txtdistrict').value;
		var state=document.getElementById('txtstate').value;
		
		var zone=document.getElementById('drpzone').value;
		var region=document.getElementById('drpregion').value;
		
		var country=document.getElementById('txtcountry').value;
		var Phone1=document.getElementById('txtphone1').value; 
		var phone2=document.getElementById('txtphone2').value;
		var mobile=document.getElementById('txtmobile').value;
		var fax=document.getElementById('txtfax').value;
		var emailid=trim(document.getElementById('txtemailid').value);
		var pan=document.getElementById('txtPan').value;
		var creditdays=document.getElementById('txtcreditdays').value;
		var remarks=trim(document.getElementById('txtremarks').value);
			
		var userid=document.getElementById('hiddenuserid').value;
		
		var Box=document.getElementById('txtbox').value; 
		var publication=document.getElementById('drpPName').value; 
		
		var edition=document.getElementById('drpEdition').value; 
		var supplement=document.getElementById('drpSuppliment').value; 
		var taluka=document.getElementById('drptaluka').value; 
        var branchcode=document.getElementById('drpbranch').value;
        var signature = document.getElementById('txtsign').value;
        var empcode = document.getElementById('hdempcode').value;
          var maincdp = document.getElementById('hiddenmaincdp').value;
           var maincds = document.getElementById('hiddenmaincds').value;
          var name="";
          var contactnam=document.getElementById('txtcontact').value.toUpperCase();
          var oldcode=document.getElementById('hdncdsubcd').value;
          var accode=document.getElementById('txtaccod').value;
          var gstus = document.getElementById('drpgstus').value;
          var gstdt = document.getElementById('txtgstdt').value;
          var gstin = document.getElementById('txtgstin').value;
          var gstatus = document.getElementById('drpgstatus').value;
          var gstcltype = document.getElementById('hdngstclty').value;
          var attachment = document.getElementById('hidattachment').value;
          var pextra1 = document.getElementById('hiddendateformat').value;
          var userid = document.getElementById('hiddenuserid').value;
		//Insert the Records 
//		RetainerMaster.RetainerStorageDetail(compcode,Retcode,retname,alias,add1,street,city,pubcent,pincode,distcode,statecode,zonecode,regioncode,country,Phone1,phone2,fax,emailid,pan,creditdays,remarks,userid,0);
		
        var creditlimit=trim(document.getElementById('txtcreditlimit').value);

        var dssave = RetainerMaster.RetainerStorage(compcode, Retcode,userid, retname, alias, add1, street, city, pubcent, pincode, dist, state, zone, region, country, Phone1, phone2, fax, emailid, pan, creditdays, remarks, 0, Box, publication, edition, supplement, taluka, repname, branchcode, creditlimit, mobile, signature, empcode, attachment, maincdp, name, contactnam, oldcode, accode, gstus, gstdt, gstin, gstatus, gstcltype, pextra1);
         //alert("dssave "+dssave.error);
         if(dssave.error!=null)
         {
            alert("Please recheck your enteries, There is problem in your entries");
            return false;
         }
		//***********************************************************************//
		if(browser!="Microsoft Internet Explorer")
                {
                    
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                var ip2=document.getElementById('ip1').value;
                   RetainerMaster.loginsertS(userid,ip2);
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}
		  //alert(xmlObj.childNodes(0).childNodes(0).text);
		    
		
		//************************************************************8//
		// for status detail pop up----------------saurabh agarwal
		

    var status=document.getElementById('hidden1s').value;
	var circular=document.getElementById('hidden2s').value;
	var fromdate=document.getElementById('hidden3s').value;
	var todate=document.getElementById('hidden4s').value;
		
	var retcode = trim(document.getElementById('txtretainercode').value);
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var fdate=new Date(fromdate);
	var tdate=new Date(todate); 
	 var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkretstatus.aspx?retcode="+retcode+"&status="+status+"&dateformat="+dateformat+"&fdate="+fromdate+"&tdate="+todate+"&circular="+circular, false );
                        httpRequest.send('');
                         id = httpRequest.responseText;
                          //alert(id)
                          
                           if (id == "yes") {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                         
//                        if (httpRequest.readyState == "yes") 
//                         {
//                                 alert('Session Expired Please Login Again.');
//                                return false;
//                         }

                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;
                                //alert(id)   
                            }
                             else 
                            {
                           // alert("derfcefc")
                                alert('Session Expired.Please Login Again.');
                                return false;
                            }
                        }
                    }  
		else
		{
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","chkretstatus.aspx?retcode="+retcode+"&status="+status+"&dateformat="+dateformat+"&fdate="+fromdate+"&tdate="+todate+"&circular="+circular, false );
		             xml.Send();
		            var dl=xml.responseText;
		}      
		             if(dl=="yes")
		            {
                        alert('Session Expired.Please Login Again.');
                        return false;
                    }
		            if(dl=="Y")
		                {
    		
		                alert("This date is already assigned");
	            	    return false;

	                	}
	                	
//	                var flag_status="true";
//	                var flag_pay="false";
//	                var flag_comm="false";
                    
                    flag_save="true";
                    flag_null="false";
                    var id;
                     if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false  );
                        httpRequest.send('');
                         id = httpRequest.responseText;
                          
                         // alert(id)
                           if (id == "yes") {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                        
//                          if (httpRequest.readyState == "yes") 
//                         {
//                                 alert('Session Expired Please Login Again.');
//                                return false;
//                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                                 //alert(id)
                            }
                            else 
                            {
                            // alert('id')
                                 alert('Session Expired.Please Login Again.');
                            }
                        }
                    }  
	                else
	                {
	                var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false );
		            xml.Send();
		            var dl=xml.responseText;
		            }
		            
		            
		            
		            // for making the session null
		            
		            var retcode = document.getElementById('hiddenretcode').value;
		            
		            flag_save="false";
                    flag_null="true";
                     var id;
                     if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false );
                        httpRequest.send('');
                        
                        
                        id = httpRequest.responseText;
                           //alert(id)
                          
                           if (id == "yes") {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                        
                        
                        
                        
//                          if (httpRequest.readyState == "yes") 
//                         {
//                                 alert('Session Expired Please Login Again.');
//                                return false;
//                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                                 //alert(id)
                            }
                            else 
                            {
                            // alert('id')
                                alert('Session Expired Please Login Again.');
                            }
                        }
                    }  
		            else
		            {
		            var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false );
		            xml.Send();
		            var dl=xml.responseText;
		            }
		            	document.getElementById('hiddensaurabh').value="0";
		            
		            flag_save="false";
                    flag_null="false";
		            
		            
//		            flag_status="false";
	               
		   // alert("Data Saved Successfully");        
	/*	  if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}
		  //alert(xmlObj.childNodes(0).childNodes(0).text);*/
		    
		    document.getElementById('txtretainercode').value="";
		document.getElementById('txtretainername').value="";
		document.getElementById('txtalias').value="";
		document.getElementById('txtadd1').value="";
		document.getElementById('drpcity').value="";
		document.getElementById('txtstreet').value="";
		document.getElementById('txtcountry').value="0";
		document.getElementById('drppubcent').value="0";
		document.getElementById('txtpincode').value="";
		document.getElementById('txtdistrict').value="";
		document.getElementById('txtstate').value="";
		document.getElementById('drpzone').value="0";
		document.getElementById('drpregion').value="0";
		
		document.getElementById('txtcountry').value="0";
		document.getElementById('txtphone1').value="";
		document.getElementById('txtphone2').value="";
		document.getElementById('txtmobile').value="";
		document.getElementById('txtfax').value="";
		document.getElementById('txtemailid').value="";
		document.getElementById('txtPan').value="";
		document.getElementById('txtcreditdays').value="";
		document.getElementById('txtremarks').value = "";  
		document.getElementById('txtbox').value = "";          
		    	document.getElementById('drpPName').value="0";
		document.getElementById('drpEdition').value = "0";  
		document.getElementById('drpSuppliment').value = "0";   
       document.getElementById('txtsign').value="";  
       document.getElementById('attachment1').value = "";
       document.getElementById('txtoldcod').value = "";
	document.getElementById('txtaccod').value = "";
		    RetCancelClick('RetainerMaster');
		    
		    
	
	}
	
return false;
}
}

function RetainerUpdate()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	//Condition Check 
	//document.getElementById('btnSave').disabled=false;
	var compcode=document.getElementById('hiddencompcode').value;
	            var Retcode=document.getElementById('txtretainercode').value;
	            var retname=trim(document.getElementById('txtretainername').value);
	            var alias=trim(document.getElementById('txtalias').value);
	            var add1=trim(document.getElementById('txtadd1').value);
	            var city=document.getElementById('drpcity').value;
	            var street=trim(document.getElementById('txtstreet').value);
	            var country=document.getElementById('txtcountry').value;
	            var repname=document.getElementById('txtrepname').value;
            	
	            var pubcent=document.getElementById('drppubcent').value;
	            var pincode=document.getElementById('txtpincode').value;
	            var dist=document.getElementById('txtdistrict').value;
	            var state=document.getElementById('txtstate').value;
	            var zone=document.getElementById('drpzone').value;
	            var region=document.getElementById('drpregion').value;
	            var country=document.getElementById('txtcountry').value;
	            var Phone1=document.getElementById('txtphone1').value; 
	            var phone2=document.getElementById('txtphone2').value;
	             var mobile=document.getElementById('txtmobile').value;
	            var fax=document.getElementById('txtfax').value;
	            var emailid=trim(document.getElementById('txtemailid').value);
	            var pan=document.getElementById('txtPan').value;
	            var creditdays=document.getElementById('txtcreditdays').value;
	            var userid=document.getElementById('hiddenuserid').value;
	            var remarks=trim(document.getElementById('txtremarks').value);
            	
		        var publication=document.getElementById('drpPName').value;
	            var edition=document.getElementById('drpEdition').value;
	            var supplement=document.getElementById('drpSuppliment').value;
	            var taluka=document.getElementById('drptaluka').value;
	            var branchcode=document.getElementById('drpbranch').value;
            	
	            var box=trim(document.getElementById('txtbox').value);
	            var creditlimit=trim(document.getElementById('txtcreditlimit').value);
	            var signature=    document.getElementById('txtsign').value;
	            var empcode = document.getElementById('hdempcode').value;
	            
	              var maincdp = document.getElementById('hiddenmaincdp').value;
	            var attachment = document.getElementById('hidattachment').value;
//	            alert(attachment)
	             var maincds = document.getElementById('hiddenmaincds').value;
	             var name = "";
	             var contactnam = document.getElementById('txtcontact').value.toUpperCase();
	             var oldcode=document.getElementById('txtoldcod').value;
	             var accode = document.getElementById('txtaccod').value;
	             var gstus = document.getElementById('drpgstus').value;
	             var gstdt = document.getElementById('txtgstdt').value;
	             var gstin = document.getElementById('txtgstin').value;
	             var gstatus = document.getElementById('drpgstatus').value;
	             var gstcltype = document.getElementById('hdngstclty').value;
                
                RetainerMaster.RetainerStorage(compcode, Retcode, retname, alias, add1, street, city, pubcent, pincode, dist, state, zone, region, country, Phone1, phone2, fax, emailid, pan, creditdays, remarks, userid, 1, box, publication, edition, supplement, taluka, repname, branchcode, creditlimit, mobile, signature, empcode, maincdp, maincds, attachment, name, contactnam, oldcode, accode, gstus, gstdt, gstin, gstatus, gstcltype);
	
                document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=false;
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
	
	
	
	            if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                    }
                    else
                    {
                    var ip2=document.getElementById('ip1').value;
                   RetainerMaster.loginsertM(userid,ip2);
                        alert(xmlObj.childNodes(0).childNodes(1).text);
                    }
            	RetainerMaster.loginsert
	                dsforexecute.Tables[0].Rows[z].Retain_Code=Retcode;
	                dsforexecute.Tables[0].Rows[z].Retain_Name=retname;
		            dsforexecute.Tables[0].Rows[z].Retain_Alias=alias;
		            dsforexecute.Tables[0].Rows[0].City_Code=city;
		            dsforexecute.Tables[0].Rows[z].Country_Code=country;
		            dsforexecute.Tables[0].Rows[z].Dist_Code=dist;
		            dsforexecute.Tables[0].Rows[z].State_Code=state;
		            dsforexecute.Tables[0].Rows[z].Zone_Code=zone;
		            dsforexecute.Tables[0].Rows[z].Region_Code=region;
		            dsforexecute.Tables[0].Rows[z].pubcent_code=pubcent;
	                dsforexecute.Tables[0].Rows[z].Street=street;
		            dsforexecute.Tables[0].Rows[z].Zip=pincode;
		            dsforexecute.Tables[0].Rows[z].Phone1=Phone1; 
		            dsforexecute.Tables[0].Rows[z].Phone2=phone2;
		            dsforexecute.Tables[0].Rows[z].MOBILENO=mobile;
		            dsforexecute.Tables[0].Rows[z].Fax=fax;
		            dsforexecute.Tables[0].Rows[z].EmailID=emailid;
		            dsforexecute.Tables[0].Rows[z].PAN_No=pan;
		            dsforexecute.Tables[0].Rows[z].Credit_Days=creditdays;
		            dsforexecute.Tables[0].Rows[z].Add1=add1;
		            dsforexecute.Tables[0].Rows[z].Remarks=remarks;	
		            dsforexecute.Tables[0].Rows[z].Branch_code=branchcode;	
            		
            	
            	
            	
            	
            	
            	
            	
	                updateStatus();
	                //document.getElementById('btnSave').disabled = true;
	                document.getElementById('txtcreditlimit').disabled=true;
	                document.getElementById('txtretainercode').disabled=true;			
	                document.getElementById('txtretainername').disabled=true;	
	                document.getElementById('txtrepname').disabled=true;		
	                document.getElementById('txtalias').disabled=true;		
	                document.getElementById('txtadd1').disabled=true;					
	                document.getElementById('txtstreet').disabled=true;			
	                document.getElementById('drpcity').disabled=true;	
                    document.getElementById('drppubcent').disabled=true;	
	                document.getElementById('txtdistrict').disabled=true;				
	                document.getElementById('txtcountry').disabled=true;					
	                document.getElementById('txtphone1').disabled=true;			
	                document.getElementById('txtphone2').disabled=true;			
	                document.getElementById('txtemailid').disabled=true;
	                document.getElementById('txtmobile').disabled=true;		
	                document.getElementById('txtPan').disabled=true;	
	                document.getElementById('txtcreditdays').disabled=true;					
	                document.getElementById('txtpincode').disabled=true;					
	                document.getElementById('txtstate').disabled=true;			
	                document.getElementById('drpzone').disabled=true;	
	                document.getElementById('drpPName').disabled=true;					
	                document.getElementById('drpEdition').disabled=true;					
	                document.getElementById('drpSuppliment').disabled=true;	
	                document.getElementById('drpregion').disabled=true;	
	                document.getElementById('txtfax').disabled=true;	
	                document.getElementById('hiddensaurabh').value="0";
	                document.getElementById('txtremarks').disabled=true;
	                document.getElementById('txtbox').disabled=true;
            	    document.getElementById('drptaluka').disabled=true;
            	    document.getElementById('drpbranch').disabled=true;
            	    document.getElementById('txtcontact').disabled=true;
            	    document.getElementById('txtoldcod').disabled = true;
	                document.getElementById('txtaccod').disabled = true;
	                document.getElementById('drpgstus').disabled = true;
	                document.getElementById('txtgstdt').disabled = true;
	                document.getElementById('txtgstin').disabled = true;
	                document.getElementById('txtgstclty').disabled = true;
	                document.getElementById('drpgstatus').disabled = true;
	                document.getElementById('btnModify').focus();
	                if(z==0)
	                {
	                 document.getElementById('btnfirst').disabled=true;
                     document.getElementById('btnprevious').disabled=true;
	                }
	                if(z==(dsforexecute.Tables[0].Rows.length-1))
	                {
	                 document.getElementById('btnnext').disabled=true;
                     document.getElementById('btnlast').disabled=true;
	                }
            	   saurabh="2";
            	   setButtonImages();
	             // return false;

    RetCancelClick('RetainerMaster');
   //RetainerMaster.chkretainercodemod(strcode,strname,fcall);
   return false;
}
	
	function fcall(response)
	{
	   var msg=checkSession();
        if(msg==false)
        return false;
        
	    var ds=response.value;
	    if(ds.Tables[0].Rows.length > 0)
		{
		  alert("This Retainer Name has already been assigned"); 
		  document.getElementById('txtretainername').value="";
		  if(document.getElementById('txtretainername').disabled==false)
		  document.getElementById('txtretainername').focus();
		  return false;
		}
		RetainerUpdate();
//		else
//		{
//	            var compcode=document.getElementById('hiddencompcode').value;
//	            var Retcode=document.getElementById('txtretainercode').value;
//	            var retname=trim(document.getElementById('txtretainername').value);
//	            var alias=trim(document.getElementById('txtalias').value);
//	            var add1=trim(document.getElementById('txtadd1').value);
//	            var city=document.getElementById('drpcity').value;
//	            var street=trim(document.getElementById('txtstreet').value);
//	            var country=document.getElementById('txtcountry').value;
//	            var repname=document.getElementById('txtrepname').value;
//            	
//	            var pubcent=document.getElementById('drppubcent').value;
//	            var pincode=document.getElementById('txtpincode').value;
//	            var dist=document.getElementById('txtdistrict').value;
//	            var state=document.getElementById('txtstate').value;
//	            var zone=document.getElementById('drpzone').value;
//	            var region=document.getElementById('drpregion').value;
//	            var country=document.getElementById('txtcountry').value;
//	            var Phone1=document.getElementById('txtphone1').value; 
//	            var phone2=document.getElementById('txtphone2').value;
//	            var fax=document.getElementById('txtfax').value;
//	            var emailid=trim(document.getElementById('txtemailid').value);
//	            var pan=document.getElementById('txtPan').value;
//	            var creditdays=document.getElementById('txtcreditdays').value;
//	            var userid=document.getElementById('hiddenuserid').value;
//	            var remarks=trim(document.getElementById('txtremarks').value);
//            	
//		        var publication=document.getElementById('drpPName').value;
//	            var edition=document.getElementById('drpEdition').value;
//	            var supplement=document.getElementById('drpSuppliment').value;
//	            var taluka=document.getElementById('drptaluka').value;
//            	
//	            var box=trim(document.getElementById('txtbox').value);
//	    
//	             RetainerMaster.RetainerStorage(compcode,Retcode,retname,alias,add1,street,city,pubcent,pincode,dist,state,zone,region,country,Phone1,phone2,fax,emailid,pan,creditdays,remarks,userid,1,box,publication,edition,supplement,taluka,repname);
//	
//                document.getElementById('btnNew').disabled=true;
//				document.getElementById('btnSave').disabled=true;
//				document.getElementById('btnModify').disabled=false;
//				document.getElementById('btnDelete').disabled=false;
//				document.getElementById('btnQuery').disabled=false;
//				document.getElementById('btnExecute').disabled=true;
//				document.getElementById('btnCancel').disabled=false;		
//				
//				document.getElementById('btnfirst').disabled=false;				
//				document.getElementById('btnnext').disabled=false;					
//				document.getElementById('btnprevious').disabled=false;			
//				document.getElementById('btnlast').disabled=false;
//				document.getElementById('btnExit').disabled=false;
//	
//	
//	
//	            if(browser!="Microsoft Internet Explorer")
//                    {
//                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
//                    }
//                    else
//                    {
//                        alert(xmlObj.childNodes(0).childNodes(1).text);
//                    }
//            	
//	                dsforexecute.Tables[0].Rows[z].Retain_Code=Retcode;
//	                dsforexecute.Tables[0].Rows[z].Retain_Name=retname;
//		            dsforexecute.Tables[0].Rows[z].Retain_Alias=alias;
//		            dsforexecute.Tables[0].Rows[0].City_Code=city;
//		            dsforexecute.Tables[0].Rows[z].Country_Code=country;
//		            dsforexecute.Tables[0].Rows[z].Dist_Code=dist;
//		            dsforexecute.Tables[0].Rows[z].State_Code=state;
//		            dsforexecute.Tables[0].Rows[z].Zone_Code=zone;
//		            dsforexecute.Tables[0].Rows[z].Region_Code=region;
//		            dsforexecute.Tables[0].Rows[z].pubcent_code=pubcent;
//	                dsforexecute.Tables[0].Rows[z].Street=street;
//		            dsforexecute.Tables[0].Rows[z].Zip=pincode;
//		            dsforexecute.Tables[0].Rows[z].Phone1=Phone1; 
//		            dsforexecute.Tables[0].Rows[z].Phone2=phone2;
//		            dsforexecute.Tables[0].Rows[z].Fax=fax;
//		            dsforexecute.Tables[0].Rows[z].EmailID=emailid;
//		            dsforexecute.Tables[0].Rows[z].PAN_No=pan;
//		            dsforexecute.Tables[0].Rows[z].Credit_Days=creditdays;
//		            dsforexecute.Tables[0].Rows[z].Add1=add1;
//		            dsforexecute.Tables[0].Rows[z].Remarks=remarks;	
//            		
//            	
//            	
//	                updateStatus();
//	                //document.getElementById('btnSave').disabled = true;
//	                document.getElementById('txtretainercode').disabled=true;			
//	                document.getElementById('txtretainername').disabled=true;	
//	                document.getElementById('txtrepname').disabled=true;		
//	                document.getElementById('txtalias').disabled=true;		
//	                document.getElementById('txtadd1').disabled=true;					
//	                document.getElementById('txtstreet').disabled=true;			
//	                document.getElementById('drpcity').disabled=true;	
//                    document.getElementById('drppubcent').disabled=true;	
//	                document.getElementById('txtdistrict').disabled=true;				
//	                document.getElementById('txtcountry').disabled=true;					
//	                document.getElementById('txtphone1').disabled=true;			
//	                document.getElementById('txtphone2').disabled=true;			
//	                document.getElementById('txtemailid').disabled=true;		
//	                document.getElementById('txtPan').disabled=true;	
//	                document.getElementById('txtcreditdays').disabled=true;					
//	                document.getElementById('txtpincode').disabled=true;					
//	                document.getElementById('txtstate').disabled=true;			
//	                document.getElementById('drpzone').disabled=true;	
//	                document.getElementById('drpPName').disabled=true;					
//	                document.getElementById('drpEdition').disabled=true;					
//	                document.getElementById('drpSuppliment').disabled=true;	
//	                document.getElementById('drpregion').disabled=true;	
//	                document.getElementById('txtfax').disabled=true;	
//	                document.getElementById('hiddensaurabh').value="0";
//	                document.getElementById('txtremarks').disabled=true;
//	                document.getElementById('txtbox').disabled=true;
//            	
//	                document.getElementById('btnModify').focus();
//	                if(z==0)
//	                {
//	                 document.getElementById('btnfirst').disabled=true;
//                     document.getElementById('btnprevious').disabled=true;
//	                }
//	                if(z==(dsforexecute.Tables[0].Rows.length-1))
//	                {
//	                 document.getElementById('btnnext').disabled=true;
//                     document.getElementById('btnlast').disabled=true;
//	                }
//            	
//	              return false;
//        }
    return false;
}



	
function RetModifyClick() 
{
flag21="N"
    show="2";
	mod="modify";
	hiddentext="Modify";
	saurabh="0";
	show1="1";
	document.getElementById('hiddensaurabh').value="modify";
	document.getElementById('hiddensubmod').value="1";
	
	modify="1";
	flag2="1";
	document.getElementById('hiddenchk').value="1";
	chknamemod=document.getElementById('txtretainername').value;
	/*document.getElementById('btnModify').disabled=true;
	document.getElementById('btnSave').disabled=false;
	document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnnext').disabled=true;					
	document.getElementById('btnprevious').disabled=true;			
	document.getElementById('btnlast').disabled=true;			
	document.getElementById('btnExit').disabled=false;
	document.getElementById('btnDelete').disabled=true;*/
document.getElementById('txtcreditlimit').disabled=false;
	document.getElementById('txtretainercode').disabled=true;			
	document.getElementById('txtretainername').disabled=false;
	document.getElementById('drppubcent').disabled=false;
	document.getElementById('txtalias').disabled=false;		
	document.getElementById('txtadd1').disabled=false;					
	document.getElementById('txtstreet').disabled=false;			
	document.getElementById('drpcity').disabled=false;			
	document.getElementById('txtdistrict').disabled=false;				
	document.getElementById('txtcountry').disabled=false;
	document.getElementById('drppubcent').disabled=false;
	document.getElementById('txtphone1').disabled=false;			
	document.getElementById('txtphone2').disabled=false;
	document.getElementById('txtmobile').disabled=false;			
	document.getElementById('txtemailid').disabled=false;		
	document.getElementById('txtPan').disabled=false;	
	document.getElementById('txtcreditdays').disabled=false;					
	document.getElementById('txtpincode').disabled=false;					
	document.getElementById('txtstate').disabled=false;			
	document.getElementById('drpzone').disabled=false;			
	document.getElementById('drpregion').disabled=false;			
	document.getElementById('txtfax').disabled=false;	
	document.getElementById('txtremarks').disabled = false;		
	document.getElementById('drpPName').disabled=false;			
	document.getElementById('drpEdition').disabled=false;			
	document.getElementById('drpSuppliment').disabled=false;	
	document.getElementById('drptaluka').disabled=false;
	document.getElementById('txtbox').disabled = false;	
    document.getElementById('txtrepname').disabled = false;
    document.getElementById('drpbranch').disabled = false;
    document.getElementById('txtemcode').disabled = false;
    document.getElementById('drpgstus').disabled = false;
    document.getElementById('txtgstdt').disabled = false;
    document.getElementById('txtgstin').disabled = false;
    document.getElementById('txtgstclty').disabled = false;
    document.getElementById('drpgstatus').disabled = false;
  document.getElementById('txtmaincdp').disabled = false;
  document.getElementById('txtcontact').disabled=false;

	chkstatus(FlagStatus);

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnSave').focus();
	
	 document.getElementById('lbtnStatusDetail').disabled=false;	
     document.getElementById('lbtnClientPaymode').disabled=false;	
     document.getElementById('lbcommdetail').disabled=false;
     document.getElementById('lblretcomslab').disabled = false;
    // document.getElementById('creaditslab').disabled = false;
         
   document.getElementById('lblsign').disabled=false;
     setButtonImages();
    return false;
}


function RetQueryClick(formname) 
{
    var msg=checkSession();
    if(msg==false)
    return false;
    flag21="Y"
    
    hiddentext="Query";
    document.getElementById('hiddensubmod').value="0";
    document.getElementById('hiddensaurabh').value="0";
    show="0";
    z=0;
    saurabh="2";
	document.getElementById('txtcreditlimit').disabled=true;
	document.getElementById('txtretainercode').disabled=false;
	document.getElementById('txtretainername').disabled=false;			
	document.getElementById('txtalias').disabled=false;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=false;			
	document.getElementById('txtdistrict').disabled=true;				
	document.getElementById('txtcountry').disabled=false;
	document.getElementById('drptaluka').disabled=true;
	document.getElementById('drppubcent').disabled=false;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;
	document.getElementById('txtmobile').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;			
	document.getElementById('drpzone').disabled=true;			
	document.getElementById('drpregion').disabled=true;			
	document.getElementById('txtfax').disabled=true;
	document.getElementById('txtbox').disabled=true;
	document.getElementById('txtremarks').disabled = true;
	document.getElementById('drpbranch').disabled = false;
	document.getElementById('txtemcode').disabled = true;
	document.getElementById('drpgstus').disabled = true;
	document.getElementById('txtgstdt').disabled = true;
	document.getElementById('txtgstin').disabled = true;
	document.getElementById('txtgstclty').disabled = true;
	document.getElementById('drpgstatus').disabled = true;
	document.getElementById('txtemcode').value = "";		
    document.getElementById('trstatus').style.display="none";
document.getElementById('txtcreditlimit').disabled="";
	document.getElementById('txtretainercode').value="";
	document.getElementById('txtretainername').value = "";
	document.getElementById('drpgstus').value = "Y";
	document.getElementById('txtgstdt').value = "";
	document.getElementById('txtgstin').value = "";
	document.getElementById('txtgstclty').value = "";
	document.getElementById('drpgstatus').value = "Y";
	document.getElementById('hdngstclty').value = "";
	document.getElementById('txtalias').value="";	
	document.getElementById('txtbox').value="";	
	document.getElementById('txtadd1').value="";					
	document.getElementById('txtstreet').value="";			
	document.getElementById('txtdistrict').value="";
	document.getElementById('drpcity').value="0";
	document.getElementById('drpbranch').value="0";
	document.getElementById('drpcity').options.length=0;
	document.getElementById('drpcity').options[0]=new Option("--Select City--","0");
						
	document.getElementById('txtcountry').value="0";	
	document.getElementById('drppubcent').value="0";				
	document.getElementById('txtphone1').value="";			
	document.getElementById('txtphone2').value="";
	document.getElementById('txtmobile').value=""			
	document.getElementById('txtemailid').value="";		
	document.getElementById('txtPan').value="";	
	document.getElementById('txtcreditdays').value="";					
	document.getElementById('txtpincode').value="";					
	document.getElementById('txtstate').value="";			
	document.getElementById('drpzone').value="0";			
	document.getElementById('drpregion').value="0";			
	document.getElementById('txtfax').value="";		
	document.getElementById('txtremarks').value = "";	
	document.getElementById('drpPName').value="0";			
	document.getElementById('drpEdition').value="0";	
	document.getElementById('drpSuppliment').value="0";	
	document.getElementById('txtrepname').value="0";	
    document.getElementById('drptaluka').value="0";
        document.getElementById('txtsign').value="";
   document.getElementById('lblsign').disabled=true;
	//document.Form1.drppubcent.focus();
	chkstatus(FlagStatus);

    document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnExecute').disabled=false;
    document.getElementById('btnSave').disabled=true;
    setButtonImages();
    document.getElementById('btnExecute').focus();
	
	 dsforexecute=null;
	 // for making the session null
		            
		            var retcode = document.getElementById('hiddenretcode').value;
		            
		            flag_save="false";
                    flag_null="true";
                    var id;
                     if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false );
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
                               alert('Session Expired Please Login Again.');
                            }
                        }
                    }  
		            else
		            {
		            var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","saveretainerpopups.aspx?retcode="+retcode+"&flag_save="+flag_save+"&flag_null="+flag_null, false );
		            xml.Send();
		            
		            var dl=xml.responseText;
		            }
		            flag_save="false";
                    flag_null="false";
                    
                     document.getElementById('lbtnStatusDetail').disabled=true;	
                     document.getElementById('lbtnClientPaymode').disabled=true;	
                     document.getElementById('lbcommdetail').disabled=true;
                     document.getElementById('lblretcomslab').disabled = true;
                    // document.getElementById('creaditslab').disabled = true;
	                return false;
	
}
function RetExecuteClick(formname) 
{
     var msg=checkSession();
        if(msg==false)
        return false;
        
    z=0;
    document.getElementById('hiddensubmod').value="0";
	var compcode=document.getElementById('hiddencompcode').value;
	
	var Retcode=document.getElementById('txtretainercode').value;
	glretaincode=Retcode;
	var Retname=document.getElementById('txtretainername').value;
	glretainname=Retname;
	var repname=document.getElementById('txtrepname').value;
	glrepname = repname;


	if (repname == "0") {
	    repname = "";
	}
	else {
	    glrepname = repname;
	}

	var alias=document.getElementById('txtalias').value;
	glalias=alias;
	var city=document.getElementById('drpcity').value;
	glcity = city;

	if (city == "0") {
	    city = "";
	}
	else {
	    glcity = city;
	}

	var pubcent=document.getElementById('drppubcent').value;
	glpubcent = pubcent;

	if (pubcent == "0") {
	    pubcent = "";
	}
	else {
	    glpubcent = pubcent;
	}

	var country=document.getElementById('txtcountry').value;
	glcountry = country;

	if (country == "0") {
	    country = "";
	}
	else {
	    glcountry = country;
	}

	var userid=document.getElementById('hiddenuserid').value;
	
	document.getElementById('hiddensaurabh').value="0";
	//document.getElementById('txtrepname').value="0";
	var Box=document.getElementById('txtbox').value;
	glbox=Box;
	var branchname=document.getElementById('drpbranch').value;
	glbranchname = branchname;

	if (branchname == "0") {
	    branchname = "";
	}
	else {
	    glbranchname = branchname;
	}
	
	var oldcode=document.getElementById('hdncdsubcd').value;
	var accode = document.getElementById('txtaccod').value;
	var gstus = document.getElementById('drpgstus').value;
	var gstdt = document.getElementById('txtgstdt').value;
	var gstin = document.getElementById('txtgstin').value;
	var gstatus = document.getElementById('drpgstatus').value;
	var gstcltype = document.getElementById('hdngstclty').value;
	var pextra1 = document.getElementById('hiddendateformat').value;
	
	var resret = RetainerMaster.RetainerExecute(compcode, Retcode, Retname, alias, city, pubcent, country, Box, repname, branchname, oldcode, accode, gstus, gstdt, gstin, gstatus, gstcltype, pextra1);
	RetainerExecute_CallBack(resret);
	updateStatus();
	       
	        
	 document.getElementById('lbtnStatusDetail').disabled=false;	
     document.getElementById('lbtnClientPaymode').disabled=false;	
     document.getElementById('lbcommdetail').disabled=false;
     document.getElementById('lblretcomslab').disabled = false;
    // document.getElementById('creaditslab').disabled = false;
       
   document.getElementById('lblsign').disabled=true;
     
     document.getElementById('lblsign').disabled=false;
    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=false;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=false;	
    setButtonImages();
    if(document.getElementById('btnModify').disabled==false)					
       document.getElementById('btnModify').focus();	
	
	return false;
	
}

function RetainerExecute_CallBack(response)
{
	
	show1="5"
	//var ds=response.value;
	dsforexecute=response.value;
	if(dsforexecute==null)
	{
	    alert(response.error.description);
	    return false;
	}   
	if(dsforexecute==""||dsforexecute=="Undefined"||dsforexecute.Tables[0].Rows.length==0)
	{
	    RetCancelClick('RetainerMaster');
		alert("Your Search Criteria Does not Produce Any Search");
		document.getElementById('txtretainercode').value="";
		document.getElementById('txtretainername').value="";			
		document.getElementById('txtalias').value="";		
		document.getElementById('txtadd1').value="";					
		document.getElementById('txtstreet').value="";			
		document.getElementById('drpcity').value="0";
		document.getElementById('drppubcent').value="0";
					
		document.getElementById('txtdistrict').value="";				
		document.getElementById('txtcountry').value="0";					
		document.getElementById('txtphone1').value="";			
		document.getElementById('txtphone2').value="";
		document.getElementById('txtmobile').value="";			
		document.getElementById('txtemailid').value="";		
		document.getElementById('txtPan').value="";	
		document.getElementById('txtcreditdays').value="";					
		document.getElementById('txtpincode').value="";					
		document.getElementById('txtstate').value="";	
		document.getElementById('drpzone').value="0";			
		document.getElementById('drpregion').value="0";			
		document.getElementById('txtfax').value="";		
		document.getElementById('txtremarks').value = "";	
		document.getElementById('drpPName').value="0";			
		document.getElementById('drpEdition').value="0";	
		document.getElementById('drpSuppliment').value="0";	
		document.getElementById('drptaluka').value="0";		
	    document.getElementById('txtrepname').value="0";	
//		document.getElementById('txtBox').value = "";
		document.getElementById('drpbranch').value = "";
		document.getElementById('txtsign').value="";
		document.getElementById('txtcontact').value="";
		
		document.getElementById('txtemcode').disabled = true;
document.getElementById('txtmaincdp').disabled = true;
		document.getElementById('attachment1').disabled = false;

		document.getElementById('drpgstus').disabled = true;
		document.getElementById('txtgstdt').disabled = true;
		document.getElementById('txtgstin').disabled = true;
		document.getElementById('txtgstclty').disabled = true;
		document.getElementById('drpgstatus').disabled = true;

		document.getElementById('txtmaincdp').value = "";	
		document.getElementById('txtemcode').value = "";		

		document.getElementById('drpgstus').value = "Y";
		document.getElementById('txtgstdt').value = "";
		document.getElementById('txtgstin').value = "";
		document.getElementById('txtgstclty').value = "";
		document.getElementById('drpgstatus').value = "Y";
		document.getElementById('hdngstclty').value = "";
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;
		document.getElementById('txtmobile').disabled=true;			
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;
        document.getElementById('drpzone').disabled=true;		
		document.getElementById('drpregion').disabled=true;		
		document.getElementById('txtfax').disabled=true;
		document.getElementById('drpPName').disabled=true;			
		document.getElementById('drpEdition').disabled=true;		
		document.getElementById('drpSuppliment').disabled=true;
		document.getElementById('drptaluka').disabled=true;		
		document.getElementById('txtrepname').disabled=true;	
		document.getElementById('drpbranch').disabled=true;	
		document.getElementById('txtcontact').disabled=true;
		document.getElementById('txtoldcod').disabled=true;
		document.getElementById('txtaccod').disabled=true;
		
//		document.getElementById('btnModify').disabled=true;
//		document.getElementById('btnDelete').disabled=true;
		return false;
	}
	
	if(dsforexecute.Tables[0].Rows.length>0)
	{	
		document.getElementById('txtretainercode').value=dsforexecute.Tables[0].Rows[0].Retain_Code;
		document.getElementById('txtretainername').value=dsforexecute.Tables[0].Rows[0].Retain_Name;
		document.getElementById('txtalias').value=dsforexecute.Tables[0].Rows[0].Retain_Alias;
	    document.getElementById('txtrepname').value=dsforexecute.Tables[0].Rows[0].repname;
		document.getElementById('drpbranch').value=dsforexecute.Tables[0].Rows[0].Branch_code;
		document.getElementById('txtcountry').value=dsforexecute.Tables[0].Rows[0].Country_Code;
		if(dsforexecute.Tables[0].Rows[0].OLDCODE!=null)
		{
		document.getElementById('txtoldcod').value=checkmultilocation(dsforexecute.Tables[0].Rows[0].OLDCODE);
		}
	        else
	        {
	        document.getElementById('txtoldcod').value="";
	        }
	    if(dsforexecute.Tables[0].Rows[0].CDP!=null)
	    {
		document.getElementById('txtaccod').value=dsforexecute.Tables[0].Rows[0].CDP;
		}
		else
		{
		document.getElementById('txtaccod').value="";
		}
////////////////////////////////GST by kanishk///////////////////////////////////////////////////		
	    if (dsforexecute.Tables[0].Rows[0].GST_REGISTRATION != null) {
	        document.getElementById('drpgstus').value = dsforexecute.Tables[0].Rows[0].GST_REGISTRATION;
	    }
	    else {
	        document.getElementById('drpgstus').value = "";
	    }
///////////////////////////////////////////////////////////
	    if (dsforexecute.Tables[0].Rows[0].GST_REGISTRATION_DATE != null) {
	        document.getElementById('txtgstdt').value = CHKDATE(dsforexecute.Tables[0].Rows[0].GST_REGISTRATION_DATE);
	    }
	    else {
	        document.getElementById('txtgstdt').value = "";
	    }

	    if (dsforexecute.Tables[0].Rows[0].GSTIN != null) {
	        document.getElementById('txtgstin').value = dsforexecute.Tables[0].Rows[0].GSTIN;
	    }
	    else {
	        document.getElementById('txtgstin').value = "";
	    }

	    if (dsforexecute.Tables[0].Rows[0].GSTAPP != null) {
	        document.getElementById('drpgstatus').value = dsforexecute.Tables[0].Rows[0].GSTAPP;
	    }
	    else {
	        document.getElementById('drpgstatus').value = "";
	    }

	    if (dsforexecute.Tables[0].Rows[0].GST_CLIENT_TYPE_CD != null) {
	        document.getElementById('hdngstclty').value = dsforexecute.Tables[0].Rows[0].GST_CLIENT_TYPE_CD;
	    }
	    else {
	        document.getElementById('hdngstclty').value = "";
	    }

//////////////////////////////////////////////////////////////////////////



	//	document.getElementById('txtcontact').value=dsforexecute.Tables[0].Rows[0].contactnam;
		cityvar=dsforexecute.Tables[0].Rows[0].City_Code;
		regionvar=dsforexecute.Tables[0].Rows[0].Region_Code;
		
		//addcount(document.getElementById('txtcountry').value);
            
            var country=document.getElementById('txtcountry').value;
            if(country!="0")
            {
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            var res=RetainerMaster.getfromc(country);
            var ds=res.value;
            var pkgitem = document.getElementById("drpcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {


            //alert(pkgitem);
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                //alert(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    
                   pkgitem.options.length;
                   
                }
                //alert(cityvar);
             
             if(cityvar == undefined || cityvar=="")
             {
              document.getElementById('drpcity').value="0";
             
             }
             else
             {
              document.getElementById('drpcity').value=cityvar;
              cityvar="";
              } 
             
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is No Matching value Found");
            }
              pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select City--","0");
            //return false;

            }

            }
            else
            {
            document.getElementById("drpcity").options.length = 1;
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            }
		
		
		document.getElementById('drpPName').value=dsforexecute.Tables[0].Rows[0].PUBLICATION; 
		
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

        RetainerMaster.fillEdiName(document.getElementById('drpPName').value,resFillEdiName);

        document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[0].pubcent_code;
		
	    adddiststate(dsforexecute.Tables[0].Rows[0].City_Code); //cityvar
		if(dsforexecute.Tables[0].Rows[0].Street!=null)
		{
		document.getElementById('txtstreet').value=dsforexecute.Tables[0].Rows[0].Street;
		}
		else
		{
		document.getElementById('txtstreet').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].CREDIT_LIMIT!=null)
		{
		document.getElementById('txtcreditlimit').value=dsforexecute.Tables[0].Rows[0].CREDIT_LIMIT;
		}
		else
		{
		document.getElementById('txtcreditlimit').value="";
		}
		//document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[0].TALUKA;
		if(dsforexecute.Tables[0].Rows[0].Zip!=null)
		{
		document.getElementById('txtpincode').value=dsforexecute.Tables[0].Rows[0].Zip;
		}
		else
		{
			document.getElementById('txtpincode').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Phone1!=null)
		{
		    document.getElementById('txtphone1').value=dsforexecute.Tables[0].Rows[0].Phone1; 
		}
		else
		{
		     document.getElementById('txtphone1').value="";   
		}
		if( dsforexecute.Tables[0].Rows[0].Phone2!=null)
		{
		        document.getElementById('txtphone2').value=dsforexecute.Tables[0].Rows[0].Phone2;
		}
		else
		{
		        document.getElementById('txtphone2').value="";
		} 
		if(dsforexecute.Tables[0].Rows[0].Fax!=null)
		{       
		     document.getElementById('txtfax').value=dsforexecute.Tables[0].Rows[0].Fax;
	    }
	    else
	    {
	          document.getElementById('txtfax').value="";
	    }	
	    if(dsforexecute.Tables[0].Rows[0].EmailID!=null)
	    {     
		      document.getElementById('txtemailid').value=dsforexecute.Tables[0].Rows[0].EmailID;
		}
		else
		{
		       document.getElementById('txtemailid').value="";
		}   
		if(dsforexecute.Tables[0].Rows[0].PAN_No!=null)
		{   
		        document.getElementById('txtPan').value=dsforexecute.Tables[0].Rows[0].PAN_No;
		}
		else
		{
		        document.getElementById('txtPan').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Credit_Days!=null)
		{
		document.getElementById('txtcreditdays').value=dsforexecute.Tables[0].Rows[0].Credit_Days;
		}
		else
	    {
	    document.getElementById('txtcreditdays').value="";
	    }
	    
	   if(dsforexecute.Tables[0].Rows[0].MOBILENO!=null)
		{
		document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[0].MOBILENO; 
		}
		else
		{
		document.getElementById('txtmobile').value="";
		}
	   
	   
	    
	    
	    /////////////////////////////////////////
	    
	    
	    if(dsforexecute.Tables[0].Rows[0].BOXMATTER!=null)
		{
		document.getElementById('txtbox').value=dsforexecute.Tables[0].Rows[0].BOXMATTER;
		}
		else
	    {
	    document.getElementById('txtbox').value="";
	    }
	    
	    ////////////////////////
	    if(dsforexecute.Tables[0].Rows[0].Add1!=null)
	    {
		document.getElementById('txtadd1').value=dsforexecute.Tables[0].Rows[0].Add1;
		}
		else
		{
		document.getElementById('txtadd1').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Remarks!=null)
		{
		      document.getElementById('txtremarks').value = dsforexecute.Tables[0].Rows[0].Remarks;	
		}
		else
		{
		       document.getElementById('txtremarks').value ="";
		}
		
		if(dsforexecute.Tables[0].Rows[0].contactnam!=null)
		{
		      document.getElementById('txtcontact').value = dsforexecute.Tables[0].Rows[0].contactnam;	
		}
		else
		{
		       document.getElementById('txtcontact').value ="";
		}
		
		//document.getElementById('txtks').value = dsforexecute.Tables[0].Rows[0].Remarks;	
		
		var from_date=dsforexecute.Tables[0].Rows[0].To_date;	
		var to_date=dsforexecute.Tables[0].Rows[0].status_date;	
		
		
		var dateformat=document.getElementById('hiddendateformat').value;
		var currentdate=dsforexecute.Tables[0].Rows[0].Creation_Datetime;
		
		//saurabh
		
		var cur=new Date();
		
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();

        var dd=cur.getDate();
		var mm=cur.getMonth() + 1;
		var yyyy=cur.getFullYear();
		
		
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="dd/mm/yyyy")
		{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		if( dsforexecute.Tables[0].Rows[0].MOBILENO!=null)
		{
		        document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[0].MOBILENO;
		}
		else
		{
		        document.getElementById('txtmobile').value="";
		}
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";
	    
	    if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('trstatus').style.display="table-row";
        }
        else
        {
            document.getElementById('trstatus').style.display="block";
        }
			
		
		document.getElementById('txtstatusdate').value = currentdate1;
		//For status of Retainer mast......................
		if((dsforexecute.Tables[0].Rows[0].Retain_status!=null)&&(dsforexecute.Tables[0].Rows[0].Retain_status!=""))
		{
		    document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[0].Retain_status;
		}
		else
		{
		    document.getElementById('txtstatus1').value="Active";
		}
		
		if((dsforexecute.Tables[0].Rows[0].SIGN!=null)&&(dsforexecute.Tables[0].Rows[0].SIGN!=""))
		{
		    document.getElementById('txtsign').value=dsforexecute.Tables[0].Rows[0].SIGN;
		}
		else
		{
		    document.getElementById('txtsign').value="";
		}


		if ((dsforexecute.Tables[0].Rows[0].HR_CODE != null) && (dsforexecute.Tables[0].Rows[0].HR_CODE != "")) {
		    document.getElementById('txtemcode').value = dsforexecute.Tables[0].Rows[0].HR_CODE;
		    var empcode1 = dsforexecute.Tables[0].Rows[0].HR_CODE; ;
		    var empcodearr = empcode1.split("(");
		    var empcodesplit = empcodearr[1];
		    empcodesplit = empcodesplit.replace(")", "");
		    document.getElementById("hdempcode").value = empcodesplit; 
		}
		else {
		    document.getElementById('txtemcode').value = "";
		}
		
		
			if ((dsforexecute.Tables[0].Rows[0].CDP != null) && (dsforexecute.Tables[0].Rows[0].CDP != "")) {
		    document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hiddenmaincdp").value = dsforexecute.Tables[0].Rows[0].CDP;
		}
		else {
		    document.getElementById('txtmaincdp').value = "";
		}

       if ((dsforexecute.Tables[0].Rows[0].CDS != null) && (dsforexecute.Tables[0].Rows[0].CDS != "")) {
		    document.getElementById('txtmaincds').value = dsforexecute.Tables[0].Rows[0].SUB_ACC_NAME;


		    document.getElementById("hiddenmaincds").value = dsforexecute.Tables[0].Rows[0].CDS;
		}
		else {
		    document.getElementById('txtmaincds').value = "";
		}





		if ((dsforexecute.Tables[0].Rows[0].ATTACHMENT != null) && (dsforexecute.Tables[0].Rows[0].ATTACHMENT != "")) {
		  //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hidattachment").value = dsforexecute.Tables[0].Rows[0].ATTACHMENT;
		    document.getElementById('attachment1').src = "Images/indexred.jpg";
		}
		else {
		    document.getElementById('hidattachment').value = "";
		}
		
		
		
		
		
	}
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtcreditlimit').disabled=true;
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;	
		document.getElementById('drpzone').disabled=true;	
		document.getElementById('drptaluka').disabled=true;
		document.getElementById('drpregion').disabled=true;	
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		document.getElementById('txtbox').disabled=true;	
		document.getElementById('txtrepname').disabled=true;	
		document.getElementById('drpbranch').disabled=true;	
		document.getElementById('drpPName').disabled=true;			
		document.getElementById('drpEdition').disabled=true;		
		document.getElementById('drpSuppliment').disabled=true;
		document.getElementById('txtcontact').disabled=true;
		document.getElementById('txtoldcod').disabled=true;
		document.getElementById('txtaccod').disabled = true;

		document.getElementById('drpgstus').disabled = true;
		document.getElementById('txtgstdt').disabled = true;
		document.getElementById('txtgstin').disabled = true;
		document.getElementById('txtgstclty').disabled = true;
		document.getElementById('drpgstatus').disabled = true;
//		document.getElementById('btnModify').disabled=false;
//		document.getElementById('btnDelete').disabled=false;
		if(dsforexecute.Tables[0].Rows.length==1)
			{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			
			}
			else
			{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			
			}	

	setButtonImages();
	return false;
}
				
function RetFirst() 
{
    var msg=checkSession();
        if(msg==false)
        return false;
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;


    show1="5";
    z=0;
	document.getElementById('txtretainercode').value=dsforexecute.Tables[0].Rows[0].Retain_Code;
	document.getElementById('txtretainername').value=dsforexecute.Tables[0].Rows[0].Retain_Name;
	document.getElementById('txtalias').value=dsforexecute.Tables[0].Rows[0].Retain_Alias;
	document.getElementById('txtrepname').value=dsforexecute.Tables[0].Rows[0].repname;
	document.getElementById('drpbranch').value=dsforexecute.Tables[0].Rows[0].Branch_code;
	document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[0].City_Code;
	document.getElementById('txtcontact').value=dsforexecute.Tables[0].Rows[0].contactnam;
	if(dsforexecute.Tables[0].Rows[0].OLDCODE!=null)
	{
	document.getElementById('txtoldcod').value=checkmultilocation(dsforexecute.Tables[0].Rows[0].OLDCODE);
	}
	else
	{
	document.getElementById('txtoldcod').value="";
	}
	if(dsforexecute.Tables[0].Rows[0].CDP!=null)
	{
	document.getElementById('txtaccod').value=dsforexecute.Tables[0].Rows[0].CDP;
	}
	    else
	    {
	    document.getElementById('txtaccod').value="";
	}
	if (dsforexecute.Tables[0].Rows[0].GST_REGISTRATION != null) {
	    document.getElementById('drpgstus').value = dsforexecute.Tables[0].Rows[0].GST_REGISTRATION;
	}
	else {
	    document.getElementById('drpgstus').value = "";
	}
    ///////////////////////////////////////////////////////////
	if (dsforexecute.Tables[0].Rows[0].GST_REGISTRATION_DATE != null) {
	    document.getElementById('txtgstdt').value = dsforexecute.Tables[0].Rows[0].GST_REGISTRATION_DATE;
	}
	else {
	    document.getElementById('txtgstdt').value = "";
	}

	if (dsforexecute.Tables[0].Rows[0].GSTIN != null) {
	    document.getElementById('txtgstin').value = dsforexecute.Tables[0].Rows[0].GSTIN;
	}
	else {
	    document.getElementById('txtgstin').value = "";
	}

	if (dsforexecute.Tables[0].Rows[0].GSTAPP != null) {
	    document.getElementById('drpgstatus').value = dsforexecute.Tables[0].Rows[0].GSTAPP;
	}
	else {
	    document.getElementById('drpgstatus').value = "";
	}

	if (dsforexecute.Tables[0].Rows[0].GST_CLIENT_TYPE_CD != null) {
	    document.getElementById('hdngstclty').value = dsforexecute.Tables[0].Rows[0].GST_CLIENT_TYPE_CD;
	}
	else {
	    document.getElementById('hdngstclty').value = "";
	}
	cityvar=dsforexecute.Tables[0].Rows[0].City_Code;
	regionvar=dsforexecute.Tables[0].Rows[0].Region_Code;
		
	document.getElementById('txtcountry').value=dsforexecute.Tables[0].Rows[0].Country_Code;
		
	//addcount(document.getElementById('txtcountry').value);
	 var country=document.getElementById('txtcountry').value;
            if(country!="0")
            {
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            var res=RetainerMaster.getfromc(country);
            var ds=res.value;
            var pkgitem = document.getElementById("drpcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {


            //alert(pkgitem);
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                //alert(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    
                   pkgitem.options.length;
                   
                }
                //alert(cityvar);
             
             if(cityvar == undefined || cityvar=="")
             {
              document.getElementById('drpcity').value="0";
             
             }
             else
             {
              document.getElementById('drpcity').value=cityvar;
              cityvar="";
              } 
             
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is No Matching value Found");
            }
              pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select City--","0");
            //return false;

            }

            }
            else
            {
            document.getElementById("drpcity").options.length = 1;
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            }
	document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[0].pubcent_code;
		
	
	document.getElementById('drpPName').value=dsforexecute.Tables[0].Rows[z].PUBLICATION; 
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

RetainerMaster.fillEdiName(document.getElementById('drpPName').value,resFillEdiName);

	document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[z].pubcent_code;
		
	
		
		adddiststate(dsforexecute.Tables[0].Rows[0].City_Code);
		if(dsforexecute.Tables[0].Rows[0].Street!=null)
		{
		document.getElementById('txtstreet').value=dsforexecute.Tables[0].Rows[0].Street;
		}
		else
		{
		document.getElementById('txtstreet').value="";
		}
		document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[0].TALUKA;
		if(dsforexecute.Tables[0].Rows[0].Zip!=null)
		{
		      document.getElementById('txtpincode').value=dsforexecute.Tables[0].Rows[0].Zip;
		}
		else
		{
		      document.getElementById('txtpincode').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Phone1!=null)
		{
		     document.getElementById('txtphone1').value=dsforexecute.Tables[0].Rows[0].Phone1; 
		}
		else
		{
		    document.getElementById('txtphone1').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].CREDIT_LIMIT!=null)
		{
		document.getElementById('txtcreditlimit').value=dsforexecute.Tables[0].Rows[0].CREDIT_LIMIT;
		}
		else
		{
		document.getElementById('txtcreditlimit').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Phone2!=null)
		{
		document.getElementById('txtphone2').value=dsforexecute.Tables[0].Rows[0].Phone2;
		}
		else
		{
		    document.getElementById('txtphone2').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Fax!=null)
		{
		document.getElementById('txtfax').value=dsforexecute.Tables[0].Rows[0].Fax;
		}
		else
		{
		     document.getElementById('txtfax').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].EmailID!=null)
		{
		document.getElementById('txtemailid').value=dsforexecute.Tables[0].Rows[0].EmailID;
		}
		else
		{ 
		         document.getElementById('txtemailid').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].PAN_No!=null)
		{
		document.getElementById('txtPan').value=dsforexecute.Tables[0].Rows[0].PAN_No;
		}
		else
		{
		    document.getElementById('txtPan').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Credit_Days!=null)
		{
		document.getElementById('txtcreditdays').value=dsforexecute.Tables[0].Rows[0].Credit_Days;
		}
		else
		{
		     document.getElementById('txtcreditdays').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Add1!=null)
		{
		document.getElementById('txtadd1').value=dsforexecute.Tables[0].Rows[0].Add1;
		}
		else
		{
			document.getElementById('txtadd1').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Remarks!=null)
		{
		document.getElementById('txtremarks').value = dsforexecute.Tables[0].Rows[0].Remarks;	
		}
		else
		{
		      document.getElementById('txtremarks').value ="";
		}
		
		if(dsforexecute.Tables[0].Rows[0].BOXMATTER!=null)
		{
		document.getElementById('txtbox').value = dsforexecute.Tables[0].Rows[0].BOXMATTER;	
		}
		else
		{
		      document.getElementById('txtbox').value ="";
		}
		
		if(dsforexecute.Tables[0].Rows[0].MOBILENO!=null)
		{
		document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[0].MOBILENO;
		}
		else
		{
		    document.getElementById('txtmobile').value="";
		}
		
		
		if(dsforexecute.Tables[0].Rows[0].SIGN!=null)
		{
		document.getElementById('txtsign').value=dsforexecute.Tables[0].Rows[0].SIGN;
		}
		else
		{
		    document.getElementById('txtsign').value="";
		}
		if ((dsforexecute.Tables[0].Rows[0].HR_CODE != null) && (dsforexecute.Tables[0].Rows[0].HR_CODE != "")) {
		    document.getElementById('txtemcode').value = dsforexecute.Tables[0].Rows[0].HR_CODE;
		    var empcode1 = dsforexecute.Tables[0].Rows[0].HR_CODE; ;
		    var empcodearr = empcode1.split("(");
		    var empcodesplit = empcodearr[1];
		    empcodesplit = empcodesplit.replace(")", "");
		    document.getElementById("hdempcode").value = empcodesplit;
		}
		else {
		    document.getElementById('txtemcode').value = "";
		}
		
		if ((dsforexecute.Tables[0].Rows[0].CDP != null) && (dsforexecute.Tables[0].Rows[0].CDP != "")) {
		    document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hiddenmaincdp").value = dsforexecute.Tables[0].Rows[0].CDP;
		}
		else {
		    document.getElementById('txtmaincdp').value = "";
		}
		
		if ((dsforexecute.Tables[0].Rows[0].CDS != null) && (dsforexecute.Tables[0].Rows[0].CDS != "")) {
		    document.getElementById('txtmaincds').value = dsforexecute.Tables[0].Rows[0].SUB_ACC_NAME;


		    document.getElementById("hiddenmaincds").value = dsforexecute.Tables[0].Rows[0].CDS;
		}
		else {
		    document.getElementById('txtmaincds').value = "";
		}
		
		
		
		
		
		if ((dsforexecute.Tables[0].Rows[0].ATTACHMENT != null) && (dsforexecute.Tables[0].Rows[0].ATTACHMENT != "")) {
		    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hidattachment").value = dsforexecute.Tables[0].Rows[0].ATTACHMENT;
		    document.getElementById('attachment1').src = "Images/indexred.jpg";
		}
		else {
		    document.getElementById('hidattachment').value = "";

		    document.getElementById('attachment1').src = "Images/index.jpeg";
		}
		
		
		
		var from_date=dsforexecute.Tables[0].Rows[0].To_date;	
		var to_date=dsforexecute.Tables[0].Rows[0].status_date;	
		
		
		var dateformat=document.getElementById('hiddendateformat').value;
		var currentdate=dsforexecute.Tables[0].Rows[0].Creation_Datetime;
		
		//saurabh
		
		var cur=new Date();
        var dd=cur.getDate();
		var mm=cur.getMonth() + 1;
		var yyyy=cur.getFullYear();
		
		if(dateformat=="yyyy/mm/dd")
		{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="dd/mm/yyyy")
		{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
		}


        if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('trstatus').style.display="table-row";
        }
        else
        {
            document.getElementById('trstatus').style.display="block";
        }
			
		document.getElementById('txtstatusdate').value = currentdate1;
		
		if((dsforexecute.Tables[0].Rows[0].Retain_status!=null)&&(dsforexecute.Tables[0].Rows[0].Retain_status!=""))
		{
//		    if(cur>=from_date && cur<=to_date)
//		    {
			    document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[0].Retain_status;
//			}
//			else
//			{
//			    document.getElementById('txtstatus1').value="Active";
//			}
			
		}
		else
		{
		    document.getElementById('txtstatus1').value="Active";
		}
		
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtoldcod').disabled=true;
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;	
		document.getElementById('drpzone').disabled=true;	
		document.getElementById('drpregion').disabled=true;	
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		document.getElementById('txtbox').disabled=true;
		document.getElementById('drpbranch').disabled=true;
		
	
	//ToolBar Disabled Status
	
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


function RetNext() 
{
   var msg=checkSession();
    if(msg==false)
    return false;

	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;

    show1="6";
    z++;
	var y=dsforexecute.Tables[0].Rows.length;
		
	if(z <= y && z !=-1 )
	{
		if(dsforexecute.Tables[0].Rows.length != z && z >= 0)
		{
			document.getElementById('txtretainercode').value=dsforexecute.Tables[0].Rows[z].Retain_Code;
		    document.getElementById('txtretainername').value=dsforexecute.Tables[0].Rows[z].Retain_Name;
		    document.getElementById('txtalias').value=dsforexecute.Tables[0].Rows[z].Retain_Alias;
		    document.getElementById('txtrepname').value=dsforexecute.Tables[0].Rows[z].repname;
		    document.getElementById('drpbranch').value=dsforexecute.Tables[0].Rows[z].Branch_code;
		    document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[z].City_Code;
		    document.getElementById('txtcontact').value=dsforexecute.Tables[0].Rows[z].contactnam;
		    if(dsforexecute.Tables[0].Rows[z].OLDCODE!=null)
		    {
		    document.getElementById('txtoldcod').value=checkmultilocation(dsforexecute.Tables[0].Rows[z].OLDCODE);
		    }
	        else
	        {
	        document.getElementById('txtoldcod').value="";
	        }
	        
	        if(dsforexecute.Tables[0].Rows[z].CDP!=null)
	        {
	        document.getElementById('txtaccod').value=dsforexecute.Tables[0].Rows[z].CDP;
	        }
	        else
	        {
	        document.getElementById('txtaccod').value="";
	        }
            ///////////////////////////////gst by kanishk///////////////////
	        if (dsforexecute.Tables[0].Rows[z].GST_REGISTRATION != null) {
	            document.getElementById('drpgstus').value = dsforexecute.Tables[0].Rows[z].GST_REGISTRATION;
	        }
	        else {
	            document.getElementById('drpgstus').value = "";
	        }
		    ///////////////////////////////////////////////////////////
	        if (dsforexecute.Tables[0].Rows[z].GST_REGISTRATION_DATE != null) {
	            document.getElementById('txtgstdt').value = dsforexecute.Tables[0].Rows[z].GST_REGISTRATION_DATE;
	        }
	        else {
	            document.getElementById('txtgstdt').value = "";
	        }

	        if (dsforexecute.Tables[0].Rows[z].GSTIN != null) {
	            document.getElementById('txtgstin').value = dsforexecute.Tables[0].Rows[z].GSTIN;
	        }
	        else {
	            document.getElementById('txtgstin').value = "";
	        }

	        if (dsforexecute.Tables[0].Rows[z].GSTAPP != null) {
	            document.getElementById('drpgstatus').value = dsforexecute.Tables[0].Rows[z].GSTAPP;
	        }
	        else {
	            document.getElementById('drpgstatus').value = "";
	        }

	        if (dsforexecute.Tables[0].Rows[z].GST_CLIENT_TYPE_CD != null) {
	            document.getElementById('hdngstclty').value = dsforexecute.Tables[0].Rows[z].GST_CLIENT_TYPE_CD;
	        }
	        else {
	            document.getElementById('hdngstclty').value = "";
	        }
		    cityvar=dsforexecute.Tables[0].Rows[z].City_Code;
		    regionvar=dsforexecute.Tables[0].Rows[z].Region_Code;
		
		    document.getElementById('txtcountry').value=dsforexecute.Tables[0].Rows[z].Country_Code;
		
		   // addcount(document.getElementById('txtcountry').value);
		    var country=document.getElementById('txtcountry').value;
            if(country!="0")
            {
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            var res=RetainerMaster.getfromc(country);
            var ds=res.value;
            var pkgitem = document.getElementById("drpcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {


            //alert(pkgitem);
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                //alert(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    
                   pkgitem.options.length;
                   
                }
                //alert(cityvar);
             
             if(cityvar == undefined || cityvar=="")
             {
              document.getElementById('drpcity').value="0";
             
             }
             else
             {
              document.getElementById('drpcity').value=cityvar;
              cityvar="";
              } 
             
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is No Matching value Found");
            }
              pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select City--","0");
            //return false;

            }

            }
            else
            {
            document.getElementById("drpcity").options.length = 1;
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            }
		    document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[z].pubcent_code;
		
	
		    document.getElementById('drpPName').value=dsforexecute.Tables[0].Rows[z].PUBLICATION; 

		

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

RetainerMaster.fillEdiName(document.getElementById('drpPName').value,resFillEdiName);

		
		
		document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[z].pubcent_code;
	
		adddiststate(dsforexecute.Tables[0].Rows[z].City_Code);
		if(dsforexecute.Tables[0].Rows[z].Street!=null)
		{
		document.getElementById('txtstreet').value=dsforexecute.Tables[0].Rows[z].Street;
		}
		else
		{
			document.getElementById('txtstreet').value="";
		}
		document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[z].TALUKA;
		if(dsforexecute.Tables[0].Rows[z].Zip!=null)
		{
		document.getElementById('txtpincode').value=dsforexecute.Tables[0].Rows[z].Zip;
		}
		else
		{
		     document.getElementById('txtpincode').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].CREDIT_LIMIT!=null)
		{
		document.getElementById('txtcreditlimit').value=dsforexecute.Tables[0].Rows[z].CREDIT_LIMIT;
		}
		else
		{
		document.getElementById('txtcreditlimit').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Phone1!=null)
		{
		document.getElementById('txtphone1').value=dsforexecute.Tables[0].Rows[z].Phone1; 
		}
		else
		{
		       document.getElementById('txtphone1').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Phone2!=null)
		{
		document.getElementById('txtphone2').value=dsforexecute.Tables[0].Rows[z].Phone2;
		}
		else
		{
		       document.getElementById('txtphone2').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Fax!=null)
		{
		document.getElementById('txtfax').value=dsforexecute.Tables[0].Rows[z].Fax;
		}
		else
		{
		       document.getElementById('txtfax').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].EmailID!=null)
		{
		document.getElementById('txtemailid').value=dsforexecute.Tables[0].Rows[z].EmailID;
		}
		else
		{
		         document.getElementById('txtemailid').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].PAN_No!=null)
		{
		document.getElementById('txtPan').value=dsforexecute.Tables[0].Rows[z].PAN_No;
		}
		else
		{
		       document.getElementById('txtPan').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Credit_Days!=null)
		{
		document.getElementById('txtcreditdays').value=dsforexecute.Tables[0].Rows[z].Credit_Days;
		}
		else
		{
		       document.getElementById('txtcreditdays').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Add1!=null)
		{
		document.getElementById('txtadd1').value=dsforexecute.Tables[0].Rows[z].Add1;
		}
		else
		{
			document.getElementById('txtadd1').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Remarks!=null)
		{
		document.getElementById('txtremarks').value = dsforexecute.Tables[0].Rows[z].Remarks;	
		}
		else
		{
		        document.getElementById('txtremarks').value = "";
		}
		
		if(dsforexecute.Tables[0].Rows[z].MOBILENO!=null)
		{
		document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[z].MOBILENO; 
		}
		else
		{
		       document.getElementById('txtmobile').value="";
		 }
		
		if(dsforexecute.Tables[0].Rows[z].SIGN!=null)
		{
		document.getElementById('txtsign').value=dsforexecute.Tables[0].Rows[z].SIGN; 
		}
		else
		{
		       document.getElementById('txtsign').value="";
		 }

		 if ((dsforexecute.Tables[0].Rows[z].HR_CODE != null) && (dsforexecute.Tables[0].Rows[z].HR_CODE != "")) {
		     document.getElementById('txtemcode').value = dsforexecute.Tables[0].Rows[z].HR_CODE;
		     var empcode1 = dsforexecute.Tables[0].Rows[z].HR_CODE; ;
		     var empcodearr = empcode1.split("(");
		     var empcodesplit = empcodearr[1];
		     empcodesplit = empcodesplit.replace(")", "");
		     document.getElementById("hdempcode").value = empcodesplit;
		 }
		 else {
		     document.getElementById('txtemcode').value = "";
		 }
		 
		 
		 	if ((dsforexecute.Tables[0].Rows[z].CDP != null) && (dsforexecute.Tables[0].Rows[z].CDP != "")) {
		    document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[z].ACC_NAME;


		    document.getElementById("hiddenmaincdp").value = dsforexecute.Tables[0].Rows[z].CDP;
		}
		else {
		    document.getElementById('txtmaincdp').value = "";
		}
		
		if ((dsforexecute.Tables[0].Rows[z].CDS != null) && (dsforexecute.Tables[0].Rows[z].CDS != "")) {
		    document.getElementById('txtmaincds').value = dsforexecute.Tables[0].Rows[z].SUB_ACC_NAME;


		    document.getElementById("hiddenmaincds").value = dsforexecute.Tables[0].Rows[z].CDS;
		}
		else {
		    document.getElementById('txtmaincds').value = "";
		}
		 
		 if ((dsforexecute.Tables[0].Rows[z].ATTACHMENT != null) && (dsforexecute.Tables[0].Rows[z].ATTACHMENT != "")) {
		    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hidattachment").value = dsforexecute.Tables[0].Rows[z].ATTACHMENT;
		    document.getElementById('attachment1').src = "Images/indexred.jpg";
		}
		else {
		    document.getElementById('hidattachment').value = "";

		    document.getElementById('attachment1').src = "Images/index.jpeg";
		}
		 
		///////////////////////////////////////
		if(dsforexecute.Tables[0].Rows[z].BOXMATTER!=null)
		{
		document.getElementById('txtbox').value = dsforexecute.Tables[0].Rows[z].BOXMATTER;	
		}
		else
		{
		        document.getElementById('txtbox').value = "";
		}
		///////////////////////////////////////
//		var dateformat=document.getElementById('hiddendateformat').value;
//		var currentdate=dsforexecute.Tables[0].Rows[z].Creation_Datetime;
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var currentdate1=yyyy+'/'+mm+'/'+dd;
//		} 
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var currentdate1=dd+'/'+mm+'/'+yyyy;
//		}
//		else
//		{
//			var currentdate1=mm+'/'+dd+'/'+yyyy;
//		}
//		
//		
//		
//		/*var todate=ds.Tables[0].Rows[0].To_date;
//		var dd1=todate.getDate();
//		var mm1=todate.getMonth() + 1;
//		var yyyy1=todate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var todate1=yyyy1+'/'+mm1+'/'+dd1;
//		} 
//		
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var todate1=dd1+'/'+mm1+'/'+yyyy1;
//		}
//		else 
//		{
//			var todate1=mm1+'/'+dd1+'/'+yyyy1;
//		}*/
//		
//				
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";
//			
//		document.getElementById('txtstatusdate').value = currentdate1;
//		
//		/*var tdate=new Date(todate1);

//		var cdate= new Date(currentdate1);

//		if(cdate>tdate)
//		{
//			document.getElementById('txtstatus1').value="Banned";
//		}
//		else
//		{*/
//		    if(dsforexecute.Tables[0].Rows[z].Retain_status!=null||dsforexecute.Tables[0].Rows[z].Retain_status!="")
//		   
//			document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[z].Retain_status;
		//}
		
		
		
		
		var from_date=dsforexecute.Tables[0].Rows[z].To_date;	
		var to_date=dsforexecute.Tables[0].Rows[z].status_date;	
		var dateformat=document.getElementById('hiddendateformat').value;
		var currentdate=dsforexecute.Tables[0].Rows[z].Creation_Datetime;
		
		//saurabh
		
		var cur=new Date();
        var dd=cur.getDate();
		var mm=cur.getMonth() + 1;
		var yyyy=cur.getFullYear();
		
		
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="dd/mm/yyyy")
		{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
		}

			
		if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('trstatus').style.display="table-row";
        }
        else
        {
            document.getElementById('trstatus').style.display="block";
        }
			
		document.getElementById('txtstatusdate').value = currentdate1;
		
		if((dsforexecute.Tables[0].Rows[z].Retain_status!=null)&&(dsforexecute.Tables[0].Rows[z].Retain_status!=""))
		{
//		    if(cur>=from_date && cur<=to_date)
//		    {
			    document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[z].Retain_status;
//			}
//			else
//			{
//			    document.getElementById('txtstatus1').value="Active";
//			}
			
		}
		else
		{
		    document.getElementById('txtstatus1').value="Active";
		}
		
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtoldcod').disabled=true;
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;
		document.getElementById('drptaluka').disabled=true;
		 document.getElementById('txtrepname').disabled=true;
		document.getElementById('drpbranch').disabled=true;
		document.getElementById('drpPName').disabled=true;					
		document.getElementById('drpEdition').disabled=true;					
		document.getElementById('drpSuppliment').disabled=true;
		
		document.getElementById('txtbox').disabled=true;
		
		document.getElementById('drpzone').disabled=true;
		document.getElementById('drpregion').disabled=true;
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		//ToolBar Disabled Status
			
			updateStatus();
				
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=false;			
			
			
		
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
	if(z==y-1)
	{
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
	}
	setButtonImages();
	return false;
}


function RetPrevious() 
{
	 var msg=checkSession();
        if(msg==false)
        return false;
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;


    show1="6";

	z--;
	var y=dsforexecute.Tables[0].Rows.length;
	
	if(z > y)
	{
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		return false;
	}

	
	
	if(z != -1 && z >= 0 )
	{
		if(dsforexecute.Tables[0].Rows.length != z)
		{
		document.getElementById('txtretainercode').value=dsforexecute.Tables[0].Rows[z].Retain_Code;
		document.getElementById('txtretainername').value=dsforexecute.Tables[0].Rows[z].Retain_Name;
		document.getElementById('txtalias').value=dsforexecute.Tables[0].Rows[z].Retain_Alias;
		 document.getElementById('txtrepname').value=dsforexecute.Tables[0].Rows[z].repname;
		document.getElementById('drpbranch').value=dsforexecute.Tables[0].Rows[z].Branch_code;
		document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[z].City_Code;
		document.getElementById('txtcontact').value=dsforexecute.Tables[0].Rows[z].contactnam;
		if(dsforexecute.Tables[0].Rows[z].OLDCODE!=null)
		{
		document.getElementById('txtoldcod').value=checkmultilocation(dsforexecute.Tables[0].Rows[z].OLDCODE);
		}
	else
	{
	document.getElementById('txtoldcod').value="";
	}
	if(dsforexecute.Tables[0].Rows[z].CDP!=null)
	{
	    document.getElementById('txtaccod').value=dsforexecute.Tables[0].Rows[z].CDP;
	    }
	    else
	    {
	    document.getElementById('txtaccod').value="";
	}

	if (dsforexecute.Tables[0].Rows[z].GST_REGISTRATION != null) {
	    document.getElementById('drpgstus').value = dsforexecute.Tables[0].Rows[z].GST_REGISTRATION;
	}
	else {
	    document.getElementById('drpgstus').value = "";
	}
		    ///////////////////////////////////////////////////////////
	if (dsforexecute.Tables[0].Rows[z].GST_REGISTRATION_DATE != null) {
	    document.getElementById('txtgstdt').value = dsforexecute.Tables[0].Rows[z].GST_REGISTRATION_DATE;
	}
	else {
	    document.getElementById('txtgstdt').value = "";
	}

	if (dsforexecute.Tables[0].Rows[z].GSTIN != null) {
	    document.getElementById('txtgstin').value = dsforexecute.Tables[0].Rows[z].GSTIN;
	}
	else {
	    document.getElementById('txtgstin').value = "";
	}

	if (dsforexecute.Tables[0].Rows[z].GSTAPP != null) {
	    document.getElementById('drpgstatus').value = dsforexecute.Tables[0].Rows[z].GSTAPP;
	}
	else {
	    document.getElementById('drpgstatus').value = "";
	}

	if (dsforexecute.Tables[0].Rows[z].GST_CLIENT_TYPE_CD != null) {
	    document.getElementById('hdngstclty').value = dsforexecute.Tables[0].Rows[z].GST_CLIENT_TYPE_CD;
	}
	else {
	    document.getElementById('hdngstclty').value = "";
	}
		cityvar=dsforexecute.Tables[0].Rows[z].City_Code;
		regionvar=dsforexecute.Tables[0].Rows[z].Region_Code;
	
		document.getElementById('txtcountry').value=dsforexecute.Tables[0].Rows[z].Country_Code;
		
		//addcount(document.getElementById('txtcountry').value);
		 var country=document.getElementById('txtcountry').value;
            if(country!="0")
            {
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            var res=RetainerMaster.getfromc(country);
            var ds=res.value;
            var pkgitem = document.getElementById("drpcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {


            //alert(pkgitem);
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                //alert(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    
                   pkgitem.options.length;
                   
                }
                //alert(cityvar);
             
             if(cityvar == undefined || cityvar=="")
             {
              document.getElementById('drpcity').value="0";
             
             }
             else
             {
              document.getElementById('drpcity').value=cityvar;
              cityvar="";
              } 
             
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is No Matching value Found");
            }
              pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select City--","0");
            //return false;

            }

            }
            else
            {
            document.getElementById("drpcity").options.length = 1;
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            }
		document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[z].pubcent_code;
		
	//	Retaddcity('ClientMaster',ds.Tables[0].Rows[0].City_Code);
		//document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[0].City_Code;
		//AD
//			if(dsforexecute.Tables[0].Rows[0].PUBLICATION!=null)
//		{
		    document.getElementById('drpPName').value=dsforexecute.Tables[0].Rows[z].PUBLICATION; 
//		}
//		else
//		{
//		     document.getElementById('drpPName').value="";   
//		}
		
//		if(dsforexecute.Tables[0].Rows[0].EDITION!=null)
//		{
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

RetainerMaster.fillEdiName(document.getElementById('drpPName').value,resFillEdiName);
		    //document.getElementById('drpEdition').value=dsforexecute.Tables[0].Rows[0].EDITION; 
//		}
//		else
//		{
//		     document.getElementById('drpEdition').value="";   
//		}
//		
//		if(dsforexecute.Tables[0].Rows[0].SUPPLEMENT!=null)
//		{
		    //document.getElementById('drpSuppliment').value=dsforexecute.Tables[0].Rows[0].SUPPLEMENT; 
//		}
//		else
//		{
//		     document.getElementById('drpSuppliment').value="";   
//		}
		
		
		document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[z].pubcent_code;
		
	//	Retaddcity('ClientMaster',ds.Tables[0].Rows[0].City_Code);
	
		
		adddiststate(dsforexecute.Tables[0].Rows[z].City_Code);
		if(dsforexecute.Tables[0].Rows[z].Street!=null)
		{
		document.getElementById('txtstreet').value=dsforexecute.Tables[0].Rows[z].Street;
		}
		else
		{
			document.getElementById('txtstreet').value="";
		}
		document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[z].TALUKA;
		if(dsforexecute.Tables[0].Rows[z].Zip!=null)
		{
		
		document.getElementById('txtpincode').value=dsforexecute.Tables[0].Rows[z].Zip;
		}
		else
		{
		         document.getElementById('txtpincode').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Phone1!=null)
		{
		document.getElementById('txtphone1').value=dsforexecute.Tables[0].Rows[z].Phone1; 
		}
		else
		{
		   document.getElementById('txtphone1').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Phone2!=null)
		{
		document.getElementById('txtphone2').value=dsforexecute.Tables[0].Rows[z].Phone2;
		}
		else
		{
		         document.getElementById('txtphone2').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].CREDIT_LIMIT!=null)
		{
		document.getElementById('txtcreditlimit').value=dsforexecute.Tables[0].Rows[z].CREDIT_LIMIT;
		}
		else
		{
		document.getElementById('txtcreditlimit').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Fax!=null)
		{
		document.getElementById('txtfax').value=dsforexecute.Tables[0].Rows[z].Fax;
		}
		else
		{    
		         document.getElementById('txtfax').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].EmailID!=null)
		{
		document.getElementById('txtemailid').value=dsforexecute.Tables[0].Rows[z].EmailID;
		}
		else
		{
		          document.getElementById('txtemailid').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].PAN_No!=null)
		{
		document.getElementById('txtPan').value=dsforexecute.Tables[0].Rows[z].PAN_No;
		}
		else
		{
		           document.getElementById('txtPan').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Credit_Days!=null)
		{
		document.getElementById('txtcreditdays').value=dsforexecute.Tables[0].Rows[z].Credit_Days;
		}
		else
		{
		           document.getElementById('txtcreditdays').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Add1!=null)
		{
		document.getElementById('txtadd1').value=dsforexecute.Tables[0].Rows[z].Add1;
		}
		else
		{
			document.getElementById('txtadd1').value="";
		}
		if(dsforexecute.Tables[0].Rows[z].Remarks!=null)
		{
		document.getElementById('txtremarks').value = dsforexecute.Tables[0].Rows[z].Remarks;	
		}
		else
		{
		         document.getElementById('txtremarks').value ="";
		}
		
		if(dsforexecute.Tables[0].Rows[z].BOXMATTER!=null)
		{
		document.getElementById('txtbox').value = dsforexecute.Tables[0].Rows[z].BOXMATTER;	
		}
		else
		{
		         document.getElementById('txtbox').value ="";
		}
		
//		var dateformat=document.getElementById('hiddendateformat').value;
//		var currentdate=dsforexecute.Tables[0].Rows[z].Creation_Datetime;
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var currentdate1=yyyy+'/'+mm+'/'+dd;
//		} 
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var currentdate1=dd+'/'+mm+'/'+yyyy;
//		}
//		else
//		{
//			var currentdate1=mm+'/'+dd+'/'+yyyy;
//		}
//		
//		
//		
//		/*var todate=ds.Tables[0].Rows[z].To_date;
//		var dd1=todate.getDate();
//		var mm1=todate.getMonth() + 1;
//		var yyyy1=todate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var todate1=yyyy1+'/'+mm1+'/'+dd1;
//		} 
//		
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var todate1=dd1+'/'+mm1+'/'+yyyy1;
//		}
//		else 
//		{
//			var todate1=mm1+'/'+dd1+'/'+yyyy1;
//		}*/
//		
//				
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";
//			
//		document.getElementById('txtstatusdate').value = currentdate1;
//		
//		/*var tdate=new Date(todate1);

//		var cdate= new Date(currentdate1);

//		if(cdate>tdate)
//		{
//			document.getElementById('txtstatus1').value="Banned";
//		}
//		else
//		{*/
//		
//		    if(dsforexecute.Tables[0].Rows[z].Retain_status!=null||dsforexecute.Tables[0].Rows[z].Retain_status!="")
//		     
//			document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[z].Retain_status;
		//}
		
		if(dsforexecute.Tables[0].Rows[z].MOBILENO!=null)
		{
		document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[z].MOBILENO;
		}
		else
		{
		         document.getElementById('txtmobile').value="";
		 }
		 
		 if(dsforexecute.Tables[0].Rows[z].SIGN!=null)
		{
		document.getElementById('txtsign').value=dsforexecute.Tables[0].Rows[z].SIGN;
		}
		else
		{
		         document.getElementById('txtsign').value="";
		 }
		 if ((dsforexecute.Tables[0].Rows[z].HR_CODE != null) && (dsforexecute.Tables[0].Rows[z].HR_CODE != "")) {
		     document.getElementById('txtemcode').value = dsforexecute.Tables[0].Rows[z].HR_CODE;
		     var empcode1 = dsforexecute.Tables[0].Rows[z].HR_CODE; ;
		     var empcodearr = empcode1.split("(");
		     var empcodesplit = empcodearr[1];
		     empcodesplit = empcodesplit.replace(")", "");
		     document.getElementById("hdempcode").value = empcodesplit;
		 }
		 else {
		     document.getElementById('txtemcode').value = "";
		 }
		 
		 
		 if ((dsforexecute.Tables[0].Rows[z].CDP != null) && (dsforexecute.Tables[0].Rows[z].CDP != "")) {
		    document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[z].ACC_NAME;


		    document.getElementById("hiddenmaincdp").value = dsforexecute.Tables[0].Rows[z].CDP;
		}
		else {
		    document.getElementById('txtmaincdp').value = "";
		}
		
		if ((dsforexecute.Tables[0].Rows[z].CDS != null) && (dsforexecute.Tables[0].Rows[z].CDS != "")) {
		    document.getElementById('txtmaincds').value = dsforexecute.Tables[0].Rows[z].SUB_ACC_NAME;


		    document.getElementById("hiddenmaincds").value = dsforexecute.Tables[0].Rows[z].CDS;
		}
		else {
		    document.getElementById('txtmaincds').value = "";
		}
		 
		 if ((dsforexecute.Tables[0].Rows[z].ATTACHMENT != null) && (dsforexecute.Tables[0].Rows[z].ATTACHMENT != "")) {
		    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hidattachment").value = dsforexecute.Tables[0].Rows[z].ATTACHMENT;
		    document.getElementById('attachment1').src = "Images/indexred.jpg";
		}
		else {
		    document.getElementById('hidattachment').value = "";

		    document.getElementById('attachment1').src = "Images/index.jpeg";
		}
		 
		 
		 
		 
		var from_date=dsforexecute.Tables[0].Rows[z].To_date;	
		var to_date=dsforexecute.Tables[0].Rows[z].status_date;	
		
		
		var dateformat=document.getElementById('hiddendateformat').value;
		var currentdate=dsforexecute.Tables[0].Rows[z].Creation_Datetime;
		
		//saurabh
		
		var cur=new Date();
		
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();

        var dd=cur.getDate();
		var mm=cur.getMonth() + 1;
		var yyyy=cur.getFullYear();
		
		
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="dd/mm/yyyy")
		{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";

        if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('trstatus').style.display="table-row";
        }
        else
        {
            document.getElementById('trstatus').style.display="block";
        }
			
		document.getElementById('txtstatusdate').value = currentdate1;
		
		if((dsforexecute.Tables[0].Rows[z].Retain_status!=null)&&(dsforexecute.Tables[0].Rows[z].Retain_status!=""))
		{
//		    if(cur>=from_date && cur<=to_date)
//		    {
			    document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[z].Retain_status;
//			}
//			else
//			{
//			    document.getElementById('txtstatus1').value="Active";
//			}
			
		}
		else
		{
		    document.getElementById('txtstatus1').value="Active";
		}
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtoldcod').disabled=true;
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;	
				document.getElementById('drpzone').disabled=true;	
				document.getElementById('drpregion').disabled=true;	
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		 document.getElementById('txtrepname').disabled=true;
		document.getElementById('txtbox').disabled=true;
		document.getElementById('drpbranch').disabled=true;
		
			//ToolBar Disabled Status
			
			updateStatus();
		
			
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;				
			document.getElementById('btnprevious').disabled=false;				
			document.getElementById('btnlast').disabled=false;			
			document.getElementById('btnExit').disabled=false;	
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
	if(z <= 0)
	{
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		setButtonImages();
		return false;

	}
	setButtonImages();
	return false;
	
}




function RetLast() 
{
	 var msg=checkSession();
        if(msg==false)
        return false;
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
    show1="7";
 
      y=dsforexecute.Tables[0].Rows.length;
	
	z=y-1;
	y=y-1;
	
	    document.getElementById('txtretainercode').value=dsforexecute.Tables[0].Rows[y].Retain_Code;
		document.getElementById('txtretainername').value=dsforexecute.Tables[0].Rows[y].Retain_Name;
		document.getElementById('txtalias').value=dsforexecute.Tables[0].Rows[y].Retain_Alias;
		 document.getElementById('txtrepname').value=dsforexecute.Tables[0].Rows[y].repname;
		 document.getElementById('drpbranch').value=dsforexecute.Tables[0].Rows[y].Branch_code;
		document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[y].City_Code;
		document.getElementById('txtcontact').value=dsforexecute.Tables[0].Rows[y].contactnam;
		if(dsforexecute.Tables[0].Rows[y].OLDCODE!=null)
		{
		document.getElementById('txtoldcod').value=checkmultilocation(dsforexecute.Tables[0].Rows[y].OLDCODE);
		}
		else
		{
		    document.getElementById('txtoldcod').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].CDP!=null)
		{
	    document.getElementById('txtaccod').value=dsforexecute.Tables[0].Rows[y].CDP;
	    }
	    else
	    {
	    document.getElementById('txtaccod').value="";
	    }
		if (dsforexecute.Tables[0].Rows[y].GST_REGISTRATION != null) {
		    document.getElementById('drpgstus').value = dsforexecute.Tables[0].Rows[y].GST_REGISTRATION;
		}
		else {
		    document.getElementById('drpgstus').value = "";
		}
    ///////////////////////////////////////////////////////////
		if (dsforexecute.Tables[0].Rows[y].GST_REGISTRATION_DATE != null) {
		    document.getElementById('txtgstdt').value = dsforexecute.Tables[0].Rows[y].GST_REGISTRATION_DATE;
		}
		else {
		    document.getElementById('txtgstdt').value = "";
		}

		if (dsforexecute.Tables[0].Rows[y].GSTIN != null) {
		    document.getElementById('txtgstin').value = dsforexecute.Tables[0].Rows[y].GSTIN;
		}
		else {
		    document.getElementById('txtgstin').value = "";
		}

		if (dsforexecute.Tables[0].Rows[y].GSTAPP != null) {
		    document.getElementById('drpgstatus').value = dsforexecute.Tables[0].Rows[y].GSTAPP;
		}
		else {
		    document.getElementById('drpgstatus').value = "";
		}

		if (dsforexecute.Tables[0].Rows[y].GST_CLIENT_TYPE_CD != null) {
		    document.getElementById('hdngstclty').value = dsforexecute.Tables[0].Rows[y].GST_CLIENT_TYPE_CD;
		}
		else {
		    document.getElementById('hdngstclty').value = "";
		}
		cityvar=dsforexecute.Tables[0].Rows[y].City_Code;
		regionvar=dsforexecute.Tables[0].Rows[y].Region_Code;
	
		document.getElementById('txtcountry').value=dsforexecute.Tables[0].Rows[y].Country_Code;
		
		//addcount(document.getElementById('txtcountry').value);
		 var country=document.getElementById('txtcountry').value;
            if(country!="0")
            {
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            var res=RetainerMaster.getfromc(country);
            var ds=res.value;
            var pkgitem = document.getElementById("drpcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {


            //alert(pkgitem);
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                //alert(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    
                   pkgitem.options.length;
                   
                }
                //alert(cityvar);
             
             if(cityvar == undefined || cityvar=="")
             {
              document.getElementById('drpcity').value="0";
             
             }
             else
             {
              document.getElementById('drpcity').value=cityvar;
              cityvar="";
              } 
             
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is No Matching value Found");
            }
              pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select City--","0");
            //return false;

            }

            }
            else
            {
            document.getElementById("drpcity").options.length = 1;
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            }
		document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[y].pubcent_code;
		
	//	Retaddcity('ClientMaster',ds.Tables[0].Rows[0].City_Code);
		//document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[0].City_Code;
		//AD
//			if(dsforexecute.Tables[0].Rows[0].PUBLICATION!=null)
//		{
		    document.getElementById('drpPName').value=dsforexecute.Tables[0].Rows[z].PUBLICATION; 
//		}
//		else
//		{
//		     document.getElementById('drpPName').value="";   
//		}
		
//		if(dsforexecute.Tables[0].Rows[0].EDITION!=null)
//		{
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

RetainerMaster.fillEdiName(document.getElementById('drpPName').value,resFillEdiName);
		    //document.getElementById('drpEdition').value=dsforexecute.Tables[0].Rows[0].EDITION; 
//		}
//		else
//		{
//		     document.getElementById('drpEdition').value="";   
//		}
//		
//		if(dsforexecute.Tables[0].Rows[0].SUPPLEMENT!=null)
//		{
		    //document.getElementById('drpSuppliment').value=dsforexecute.Tables[0].Rows[0].SUPPLEMENT; 
//		}
//		else
//		{
//		     document.getElementById('drpSuppliment').value="";   
//		}
		
		
		document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[y].pubcent_code;
		
	//	Retaddcity('ClientMaster',ds.Tables[0].Rows[0].City_Code);
		
		adddiststate(dsforexecute.Tables[0].Rows[y].City_Code);
		if(dsforexecute.Tables[0].Rows[y].Street!=null)
		{
		document.getElementById('txtstreet').value=dsforexecute.Tables[0].Rows[y].Street;
		}
		else
		{
		document.getElementById('txtstreet').value="";
		}
	     document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[y].TALUKA;
		if(dsforexecute.Tables[0].Rows[y].Zip!=null)
		{
		document.getElementById('txtpincode').value=dsforexecute.Tables[0].Rows[y].Zip;
		}
		else
		{
		     document.getElementById('txtpincode').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].Phone1!=null)
		{
		document.getElementById('txtphone1').value=dsforexecute.Tables[0].Rows[y].Phone1; 
		}
		else
		{
		      document.getElementById('txtphone1').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].Phone2!=null)
		{
		
		document.getElementById('txtphone2').value=dsforexecute.Tables[0].Rows[y].Phone2;
		}
		else
		{
		      document.getElementById('txtphone2').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].Fax!=null)
		{
		document.getElementById('txtfax').value=dsforexecute.Tables[0].Rows[y].Fax;
		}
		else
		{
		       document.getElementById('txtfax').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].EmailID!=null)
		{
		document.getElementById('txtemailid').value=dsforexecute.Tables[0].Rows[y].EmailID;
		}
		else
		{
		       document.getElementById('txtemailid').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].PAN_No!=null)
		{
		document.getElementById('txtPan').value=dsforexecute.Tables[0].Rows[y].PAN_No;
		}
		else
		{
		     document.getElementById('txtPan').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].Credit_Days!=null)
		{
		
		
		document.getElementById('txtcreditdays').value=dsforexecute.Tables[0].Rows[y].Credit_Days;
		}
		else
		{
		        document.getElementById('txtcreditdays').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].Add1!=null)
		{
		document.getElementById('txtadd1').value=dsforexecute.Tables[0].Rows[y].Add1;
		}
		else
		{
		document.getElementById('txtadd1').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].CREDIT_LIMIT!=null)
		{
		document.getElementById('txtcreditlimit').value=dsforexecute.Tables[0].Rows[y].CREDIT_LIMIT;
		}
		else
		{
		document.getElementById('txtcreditlimit').value="";
		}
		if(dsforexecute.Tables[0].Rows[y].Remarks!=null)
		{
		document.getElementById('txtremarks').value = dsforexecute.Tables[0].Rows[y].Remarks;	
		}
		else
		{
		     document.getElementById('txtremarks').value ="";
		}
		
		if(dsforexecute.Tables[0].Rows[y].BOXMATTER!=null)
		{
		document.getElementById('txtbox').value = dsforexecute.Tables[0].Rows[y].BOXMATTER;	
		}
		else
		{
		     document.getElementById('txtbox').value ="";
		}
		
//		var dateformat=document.getElementById('hiddendateformat').value;
//		var currentdate=dsforexecute.Tables[0].Rows[y].Creation_Datetime;
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var currentdate1=yyyy+'/'+mm+'/'+dd;
//		} 
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var currentdate1=dd+'/'+mm+'/'+yyyy;
//		}
//		else
//		{
//			var currentdate1=mm+'/'+dd+'/'+yyyy;
//		}
//		
//		
//		
//		/*var todate=ds.Tables[0].Rows[0].To_date;
//		var dd1=todate.getDate();
//		var mm1=todate.getMonth() + 1;
//		var yyyy1=todate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var todate1=yyyy1+'/'+mm1+'/'+dd1;
//		} 
//		
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var todate1=dd1+'/'+mm1+'/'+yyyy1;
//		}
//		else 
//		{
//			var todate1=mm1+'/'+dd1+'/'+yyyy1;
//		}*/
//		
//				
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";
//			
//		document.getElementById('txtstatusdate').value = currentdate1;
		
		/*var tdate=new Date(todate1);

		var cdate= new Date(currentdate1);

		if(cdate>tdate)
		{
			document.getElementById('txtstatus1').value="Banned";
		}
		else
		{*/
//		    if(dsforexecute.Tables[0].Rows[y].Retain_status!=null||dsforexecute.Tables[0].Rows[y].Retain_status!="")
//			  document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[y].Retain_status;
//		//}

     if(dsforexecute.Tables[0].Rows[y].MOBILENO!=null)
		{
		
		document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[y].MOBILENO;
		}
		else
		{
		      document.getElementById('txtmobile').value="";
		}

  if(dsforexecute.Tables[0].Rows[y].SIGN!=null)
		{
		
		document.getElementById('txtsign').value=dsforexecute.Tables[0].Rows[y].SIGN;
		}
		else
		{
		      document.getElementById('txtsign').value="";
		  }
		if ((dsforexecute.Tables[0].Rows[y].HR_CODE != null) && (dsforexecute.Tables[0].Rows[y].HR_CODE != "")) {
		    document.getElementById('txtemcode').value = dsforexecute.Tables[0].Rows[y].HR_CODE;
		    var empcode1 = dsforexecute.Tables[0].Rows[y].HR_CODE; ;
		    var empcodearr = empcode1.split("(");
		    var empcodesplit = empcodearr[1];
		    empcodesplit = empcodesplit.replace(")", "");
		    document.getElementById("hdempcode").value = empcodesplit;
		}
		else {
		    document.getElementById('txtemcode').value = "";
		}


if ((dsforexecute.Tables[0].Rows[z].CDP != null) && (dsforexecute.Tables[0].Rows[z].CDP != "")) {
		    document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[z].ACC_NAME;


		    document.getElementById("hiddenmaincdp").value = dsforexecute.Tables[0].Rows[z].CDP;
		}
		else {
		    document.getElementById('txtmaincdp').value = "";
		}
		
		if ((dsforexecute.Tables[0].Rows[z].CDS != null) && (dsforexecute.Tables[0].Rows[z].CDS != "")) {
		    document.getElementById('txtmaincds').value = dsforexecute.Tables[0].Rows[z].SUB_ACC_NAME;


		    document.getElementById("hiddenmaincds").value = dsforexecute.Tables[0].Rows[z].CDS;
		}
		else {
		    document.getElementById('txtmaincds').value = "";
		}
		 
		 if ((dsforexecute.Tables[0].Rows[z].ATTACHMENT != null) && (dsforexecute.Tables[0].Rows[z].ATTACHMENT != "")) {
		    //  document.getElementById('txtmaincdp').value = dsforexecute.Tables[0].Rows[0].ACC_NAME;


		    document.getElementById("hidattachment").value = dsforexecute.Tables[0].Rows[z].ATTACHMENT;
		    document.getElementById('attachment1').src = "Images/indexred.jpg";
		}
		else {
		    document.getElementById('hidattachment').value = "";

		    document.getElementById('attachment1').src = "Images/index.jpeg";
		}




        var from_date=dsforexecute.Tables[0].Rows[y].To_date;	
		var to_date=dsforexecute.Tables[0].Rows[y].status_date;	
		
		
		var dateformat=document.getElementById('hiddendateformat').value;
		var currentdate=dsforexecute.Tables[0].Rows[y].Creation_Datetime;
		
		//saurabh
		
		var cur=new Date();
		
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();

        var dd=cur.getDate();
		var mm=cur.getMonth() + 1;
		var yyyy=cur.getFullYear();
		
		
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="dd/mm/yyyy")
		{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";

        if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('trstatus').style.display="table-row";
        }
        else
        {
            document.getElementById('trstatus').style.display="block";
        }
			
		document.getElementById('txtstatusdate').value = currentdate1;
		
		if((dsforexecute.Tables[0].Rows[y].Retain_status!=null)&&(dsforexecute.Tables[0].Rows[y].Retain_status!=""))
		{
//		    if(cur>=from_date && cur<=to_date)
//		    {
			    document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[y].Retain_status;
//			}
//			else
//			{
//			    document.getElementById('txtstatus1').value="Active";
//			}
			
		}
	    else
		{
		    document.getElementById('txtstatus1').value="Active";
		}
		
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;	
		document.getElementById('txtrepname').disabled=true;	
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		document.getElementById('txtoldcod').disabled=true;
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;	
		document.getElementById('drpzone').disabled=true;	
		document.getElementById('drpregion').disabled=true;	
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		 document.getElementById('txtrepname').disabled=true;
		document.getElementById('txtbox').disabled=true;
		document.getElementById('drpbranch').disabled=true;
	
	//ToolBar Disabled Status
	updateStatus();
	
	document.getElementById('btnfirst').disabled=false;				
	document.getElementById('btnnext').disabled=true;					
	document.getElementById('btnprevious').disabled=false;	
	document.getElementById('btnlast').disabled=true;	
	document.getElementById('btnExit').disabled=false;	
	setButtonImages();
	return false;
	
}

//Delete Function  
function RetDelete()
{
	 var msg=checkSession();
        if(msg==false)
        return false;
	var compcode=document.getElementById('hiddencompcode').value;
	var Retcode=document.getElementById('txtretainercode').value;
	var userid=document.getElementById('hiddenuserid').value;

	if (confirm("Are you sure you want to delete")) 
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
       
     var res1=RetainerMaster.Retainerchkname(compcode,Retcode);
    var ds1=res1.value;
    if(ds1.Tables[0].Rows.length >0)
    {
    alert("Data Can't be deleted bcz. name used in booking");
    return false;
    }
RetainerMaster.RetainerDelete(compcode,Retcode);
		
		//alert("Data Deleted Successfully");
		//alert(xmlObj.childNodes(0).childNodes(2).text);
			if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
                var ip2=document.getElementById('ip1').value;
                   RetainerMaster.loginsertD(userid,ip2);
				    alert(xmlObj.childNodes(0).childNodes(2).text);
				}
				var oldcode="";
                var accode="";
		
		      RetainerMaster.RetainerExecute(compcode,glretaincode,glretainname,glalias,glcity,glpubcent,glcountry,glbox,glrepname,glbranchname,oldcode,accode,Delete_CallBack);
				
	}
	
	return false;
}

function Delete_CallBack(response)
{
	dsforexecute = response.value;
	var y = dsforexecute.Tables[0].Rows.length;
	
	if( y <=0 )
	{
	
	
	alert("There is no Data");
		
	    document.getElementById('txtretainercode').value="";
		document.getElementById('txtretainername').value="";			
		document.getElementById('txtalias').value="";		
		document.getElementById('txtadd1').value="";					
		document.getElementById('txtstreet').value="";			
		document.getElementById('drpcity').value="0";			
		document.getElementById('txtdistrict').value="";				
		document.getElementById('txtcountry').value="0";					
		document.getElementById('txtphone1').value="";			
		document.getElementById('txtphone2').value="";	
		document.getElementById('txtmobile').value="";		
		document.getElementById('txtemailid').value="";		
		document.getElementById('txtPan').value="";	
		document.getElementById('txtcreditdays').value="";					
		document.getElementById('txtpincode').value="";					
		document.getElementById('txtstate').value="";	
		document.getElementById('drpzone').value="0";	
		document.getElementById('drpregion').value="0";	
		document.getElementById('txtfax').value="";		
		document.getElementById('txtremarks').value = "";	
		document.getElementById('txtrepname').value = "";	
		document.getElementById('txtbox').value = "";	
		document.getElementById('drpbranch').value = "0";	
		
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;	
		document.getElementById('drpzone').disabled=true;			
		document.getElementById('drpregion').disabled=true;			
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		document.getElementById('txtrepname').disabled=true;
		document.getElementById('drpbranch').disabled=true;
		RetCancelClick('RetainerMaster');
		
		return false;
	
	}
	else if(z==-1 ||z>=y)
	{
	show1="5";
	       document.getElementById('txtretainercode').value=dsforexecute.Tables[0].Rows[0].Retain_Code;
		document.getElementById('txtretainername').value=dsforexecute.Tables[0].Rows[0].Retain_Name;
		document.getElementById('txtalias').value=dsforexecute.Tables[0].Rows[0].Retain_Alias;
		document.getElementById('txtrepname').value=dsforexecute.Tables[0].Rows[0].repname;
		document.getElementById('drpbranch').value=dsforexecute.Tables[0].Rows[0].Branch_code;
		document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[0].City_Code;
		cityvar=dsforexecute.Tables[0].Rows[0].City_Code;
		regionvar=dsforexecute.Tables[0].Rows[0].Region_Code;
	
		document.getElementById('txtcountry').value=dsforexecute.Tables[0].Rows[0].Country_Code;
		
		//addcount(document.getElementById('txtcountry').value);
		 var country=document.getElementById('txtcountry').value;
            if(country!="0")
            {
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            var res=RetainerMaster.getfromc(country);
            var ds=res.value;
            var pkgitem = document.getElementById("drpcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {


            //alert(pkgitem);
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                //alert(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    
                   pkgitem.options.length;
                   
                }
                //alert(cityvar);
             
             if(cityvar == undefined || cityvar=="")
             {
              document.getElementById('drpcity').value="0";
             
             }
             else
             {
              document.getElementById('drpcity').value=cityvar;
              cityvar="";
              } 
             
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is No Matching value Found");
            }
              pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select City--","0");
            //return false;

            }

            }
            else
            {
            document.getElementById("drpcity").options.length = 1;
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            }
		document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[0].pubcent_code;
		
	//	Retaddcity('ClientMaster',ds.Tables[0].Rows[0].City_Code);
		
		
		adddiststate(dsforexecute.Tables[0].Rows[0].City_Code);
		if(dsforexecute.Tables[0].Rows[0].Street!=null)
		{
		document.getElementById('txtstreet').value=dsforexecute.Tables[0].Rows[0].Street;
		}
		else
		{
		document.getElementById('txtstreet').value="";
		}
		document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[0].TALUKA;
		if(dsforexecute.Tables[0].Rows[0].Zip!=null)
		{
		document.getElementById('txtpincode').value=dsforexecute.Tables[0].Rows[0].Zip;
		}
		else
		{
		document.getElementById('txtpincode').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Phone1!=null)
		{
		document.getElementById('txtphone1').value=dsforexecute.Tables[0].Rows[0].Phone1; 
		}
		else
		{
		document.getElementById('txtphone1').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Phone2!=null)
		{
		document.getElementById('txtphone2').value=dsforexecute.Tables[0].Rows[0].Phone2;
		}
		else
		{
		document.getElementById('txtphone2').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Fax!=null)
		{
		document.getElementById('txtfax').value=dsforexecute.Tables[0].Rows[0].Fax;
		}
		else
		{
		document.getElementById('txtfax').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].EmailID!=null)
		{
		document.getElementById('txtemailid').value=dsforexecute.Tables[0].Rows[0].EmailID;
		}
		else
		{
			document.getElementById('txtemailid').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].CREDIT_LIMIT!=null)
		{
		document.getElementById('txtcreditlimit').value=dsforexecute.Tables[0].Rows[0].CREDIT_LIMIT;
		}
		else
		{
		document.getElementById('txtcreditlimit').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].PAN_No!=null)
		{
		document.getElementById('txtPan').value=dsforexecute.Tables[0].Rows[0].PAN_No;
		}
		else
		{
		document.getElementById('txtPan').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Credit_Days!=null)
		{
		document.getElementById('txtcreditdays').value=dsforexecute.Tables[0].Rows[0].Credit_Days;
		}
		else
		{
		document.getElementById('txtcreditdays').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Add1!=null)
		{
		document.getElementById('txtadd1').value=dsforexecute.Tables[0].Rows[0].Add1;
		}
		else
		{
		document.getElementById('txtadd1').value="";
		}
		if(dsforexecute.Tables[0].Rows[0].Remarks!=null)
		{
		document.getElementById('txtremarks').value = dsforexecute.Tables[0].Rows[0].Remarks;	
		}
		else
		{
			document.getElementById('txtremarks').value ="";
		}
		
		if(dsforexecute.Tables[0].Rows[0].BOXMATTER!=null)
		{
		document.getElementById('txtbox').value = dsforexecute.Tables[0].Rows[0].BOXMATTER;	
		}
		else
		{
			document.getElementById('txtbox').value ="";
		}
		
		if(dsforexecute.Tables[0].Rows[0].MOBILENO!=null)
		{
		document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[0].MOBILENO; 
		}
		else
		{
		document.getElementById('txtmobile').value="";
		}
		
		
		
//		var dateformat=document.getElementById('hiddendateformat').value;
//		var currentdate=dsforexecute.Tables[0].Rows[0].Creation_Datetime;
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var currentdate1=yyyy+'/'+mm+'/'+dd;
//		} 
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var currentdate1=dd+'/'+mm+'/'+yyyy;
//		}
//		else
//		{
//			var currentdate1=mm+'/'+dd+'/'+yyyy;
//		}
//		
//		
//		
//		/*var todate=ds.Tables[0].Rows[0].To_date;
//		var dd1=todate.getDate();
//		var mm1=todate.getMonth() + 1;
//		var yyyy1=todate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var todate1=yyyy1+'/'+mm1+'/'+dd1;
//		} 
//		
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var todate1=dd1+'/'+mm1+'/'+yyyy1;
//		}
//		else 
//		{
//			var todate1=mm1+'/'+dd1+'/'+yyyy1;
//		}*/
//		
//				
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";
//			
//		document.getElementById('txtstatusdate').value = currentdate1;
//		
//		/*var tdate=new Date(todate1);

//		var cdate= new Date(currentdate1);

//		if(cdate>tdate)
//		{
//			document.getElementById('txtstatus1').value="Banned";
//		}
//		else
//		{*/
//			document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[0].Retain_status;
		//}
		
		
		var from_date=dsforexecute.Tables[0].Rows[0].To_date;	
		var to_date=dsforexecute.Tables[0].Rows[0].status_date;	
		
		
		var dateformat=document.getElementById('hiddendateformat').value;
		var currentdate=dsforexecute.Tables[0].Rows[0].Creation_Datetime;
		
		//saurabh
		
		var cur=new Date();
		
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();

        var dd=cur.getDate();
		var mm=cur.getMonth() + 1;
		var yyyy=cur.getFullYear();
		
		
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="dd/mm/yyyy")
		{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
//		
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";

        if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('trstatus').style.display="table-row";
        }
        else
        {
            document.getElementById('trstatus').style.display="block";
        }
			
		document.getElementById('txtstatusdate').value = currentdate1;
		
		if((dsforexecute.Tables[0].Rows[0].Retain_status!=null)&&(dsforexecute.Tables[0].Rows[0].Retain_status!=""))
		{
//		    if(cur>=from_date && cur<=to_date)
//		    {
			    document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[0].Retain_status;
//			}
//			else
//			{
//			    document.getElementById('txtstatus1').value="Active";
//			}
			
		}
		else
		{
		    document.getElementById('txtstatus1').value="Active";
		}
		
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;
		document.getElementById('txtrepname').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;	
		document.getElementById('drpzone').disabled=true;	
		document.getElementById('drpregion').disabled=true;	
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		document.getElementById('txtbox').disabled=true;
		document.getElementById('drpbranch').disabled=true;
		document.getElementById('drpPName').disabled=true;
		document.getElementById('drpEdition').disabled=true;
		document.getElementById('drpSuppliment').disabled=true;
		setButtonImages();	
	return false;
	}
	
	else
	{
	    show1="6";
	    document.getElementById('txtretainercode').value=dsforexecute.Tables[0].Rows[z].Retain_Code;
		document.getElementById('txtretainername').value=dsforexecute.Tables[0].Rows[z].Retain_Name;
		document.getElementById('txtalias').value=dsforexecute.Tables[0].Rows[z].Retain_Alias;
		document.getElementById('txtrepname').value=dsforexecute.Tables[0].Rows[z].repname;
		document.getElementById('drpbranch').value=dsforexecute.Tables[0].Rows[z].Branch_code;
		document.getElementById('drpcity').value=dsforexecute.Tables[0].Rows[0].City_Code;
		cityvar=dsforexecute.Tables[0].Rows[z].City_Code;
		regionvar=dsforexecute.Tables[0].Rows[z].Region_Code;
		
		document.getElementById('txtcountry').value=dsforexecute.Tables[0].Rows[z].Country_Code;
		
		//addcount(document.getElementById('txtcountry').value);
		 var country=document.getElementById('txtcountry').value;
            if(country!="0")
            {
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            var res=RetainerMaster.getfromc(country);
            var ds=res.value;
            var pkgitem = document.getElementById("drpcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {


            //alert(pkgitem);
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                //alert(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    
                   pkgitem.options.length;
                   
                }
                //alert(cityvar);
             
             if(cityvar == undefined || cityvar=="")
             {
              document.getElementById('drpcity').value="0";
             
             }
             else
             {
              document.getElementById('drpcity').value=cityvar;
              cityvar="";
              } 
             
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is No Matching value Found");
            }
              pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select City--","0");
            //return false;

            }

            }
            else
            {
            document.getElementById("drpcity").options.length = 1;
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
            }
		document.getElementById('drppubcent').value=dsforexecute.Tables[0].Rows[z].pubcent_code;
		document.getElementById('drpregion').value=dsforexecute.Tables[0].Rows[0].Region_Code;
		
	//	Retaddcity('ClientMaster',ds.Tables[0].Rows[0].City_Code);
		
		
		adddiststate(dsforexecute.Tables[0].Rows[z].City_Code);
		document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[z].TALUKA;
		document.getElementById('txtstreet').value=dsforexecute.Tables[0].Rows[z].Street;
		document.getElementById('txtpincode').value=dsforexecute.Tables[0].Rows[z].Zip;
		document.getElementById('txtphone1').value=dsforexecute.Tables[0].Rows[z].Phone1; 
		document.getElementById('txtphone2').value=dsforexecute.Tables[0].Rows[z].Phone2;
		document.getElementById('txtmobile').value=dsforexecute.Tables[0].Rows[z].MOBILENO;
		document.getElementById('txtfax').value=dsforexecute.Tables[0].Rows[z].Fax;
		document.getElementById('txtemailid').value=dsforexecute.Tables[0].Rows[z].EmailID;
		document.getElementById('txtPan').value=dsforexecute.Tables[0].Rows[z].PAN_No;
		document.getElementById('txtcreditdays').value=dsforexecute.Tables[0].Rows[z].Credit_Days;
		document.getElementById('txtadd1').value=dsforexecute.Tables[0].Rows[z].Add1;
		document.getElementById('txtremarks').value = dsforexecute.Tables[0].Rows[z].Remarks;
		document.getElementById('txtbox').value = dsforexecute.Tables[0].Rows[z].BOXMATTER;	
		
		
//		var dateformat=document.getElementById('hiddendateformat').value;
//		var currentdate=dsforexecute.Tables[0].Rows[z].Creation_Datetime;
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var currentdate1=yyyy+'/'+mm+'/'+dd;
//		} 
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var currentdate1=dd+'/'+mm+'/'+yyyy;
//		}
//		else
//		{
//			var currentdate1=mm+'/'+dd+'/'+yyyy;
//		}
//		
//		
//		
//		/*var todate=ds.Tables[0].Rows[z].To_date;
//		var dd1=todate.getDate();
//		var mm1=todate.getMonth() + 1;
//		var yyyy1=todate.getFullYear();
//		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//		
//		if(dateformat=="yyyy/mm/dd")
//		{
//			var todate1=yyyy1+'/'+mm1+'/'+dd1;
//		} 
//		
//		else if (dateformat=="dd/mm/yyyy")
//		{
//			var todate1=dd1+'/'+mm1+'/'+yyyy1;
//		}
//		else 
//		{
//			var todate1=mm1+'/'+dd1+'/'+yyyy1;
//		}*/
//		
//				
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";
//			
//		document.getElementById('txtstatusdate').value = currentdate1;
//		
//		/*var tdate=new Date(todate1);

//		var cdate= new Date(currentdate1);

//		if(cdate>tdate)
//		{
//			document.getElementById('txtstatus1').value="Banned";
//		}
//		else
//		{*/
//		    if(dsforexecute.Tables[0].Rows[z].Retain_status!=null||dsforexecute.Tables[0].Rows[z].Retain_status!="")
//		    
//			document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[z].Retain_status;
		//}
		
		var from_date=dsforexecute.Tables[0].Rows[z].To_date;	
		var to_date=dsforexecute.Tables[0].Rows[z].status_date;	
		
		
		var dateformat=document.getElementById('hiddendateformat').value;
		var currentdate=dsforexecute.Tables[0].Rows[z].Creation_Datetime;
		
		//saurabh
		
		var cur=new Date();
		
//		var dd=currentdate.getDate();
//		var mm=currentdate.getMonth() + 1;
//		var yyyy=currentdate.getFullYear();

        var dd=cur.getDate();
		var mm=cur.getMonth() + 1;
		var yyyy=cur.getFullYear();
		
		
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="dd/mm/yyyy")
		{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		
//		document.getElementById('txtstatus1').style.visibility = "visible";
//		document.getElementById('txtstatusdate').style.visibility = "visible";
//		document.getElementById('Label31').style.visibility="visible";
//		document.getElementById('Label23').style.visibility="visible";
			
		if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('trstatus').style.display="table-row";
        }
        else
        {
            document.getElementById('trstatus').style.display="block";
        }
			
		document.getElementById('txtstatusdate').value = currentdate1;
		
		if((dsforexecute.Tables[0].Rows[z].Retain_status!=null)&&(dsforexecute.Tables[0].Rows[z].Retain_status!=""))
		{
//		    if(cur>=from_date && cur<=to_date)
//		    {
			    document.getElementById('txtstatus1').value=dsforexecute.Tables[0].Rows[z].Retain_status;
//			}
//			else
//			{
//			    document.getElementById('txtstatus1').value="Active";
//			}
			
		}
		else
		{
		    document.getElementById('txtstatus1').value="Active";
		}
		
		
		
		document.getElementById('txtretainercode').disabled=true;
		document.getElementById('txtretainername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtrepname').disabled=true;	
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;
		
		document.getElementById('drppubcent').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;	
		document.getElementById('txtmobile').disabled=true;		
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;
		document.getElementById('drpzone').disabled=true;
		document.getElementById('drpregion').disabled=true;
		document.getElementById('txtfax').disabled=true;		
		document.getElementById('txtstatus1').disabled=true;
		document.getElementById('txtstatusdate').disabled=true;
		document.getElementById('txtremarks').disabled=true;
		document.getElementById('drpbranch').disabled=true;
		setButtonImages();
	    return false;
	}
	
	
}





/*===================================Pop Up=========================================*/



/*=================================================================================*/

//Pop Up Opening
/*function RetainerPayMode() 
{
	var RetPayCode= document.getElementById('txtretainercode').value;
	
	window.open("RetainerPaymode.aspx?RetPayCode="+RetPayCode,"_blank","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
	return false;
}
function RetainerCommissionDetail() 
{
	var RetCode= document.getElementById('txtretainercode').value;
	window.open("RetainerCommDetails.aspx?Retcode="+RetCode,"_blank","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
	return false;
}
function RetainerStatusDetail()
{
	var RetStatusCode= document.getElementById('txtretainercode').value;
	window.open("RetainerStatusMaster.aspx?RetStatusCode="+RetStatusCode,"_blank","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
	return false;
}*/

function  RetainerStatusDetail()
{ 

if ((trim(document.getElementById('txtretainercode').value)!="")&&(document.getElementById('txtretainercode').value!=null))
    {
  for ( var index = 0; index < 200; index++ ) 
  { 
 
var RetStatusCode= document.getElementById('txtretainercode').value;
	//var agencysubcode=document.getElementById('txtsagencycode').value;
    popUpWin = window.open("RetainerStatusMaster.aspx?show="+show+"&n_m="+saurabh+"&RetStatusCode="+RetStatusCode,"status","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
   //  RetStatusCode="+RetStatusCode+"&show="+show+"&n_m="+saurabh
  popUpWin.focus();
     return false;
  } 
  return false;
}
else
{
    if(document.getElementById('hiddenauto')==1)
    {
        alert("Please enter the Retainer Code");
    document.getElementById('txtretainercode').disabled=false;
    document.getElementById('txtretainercode').value="";
    document.getElementById('txtretainercode').focus();
    return false;
    }
    else
    {
    alert("Please enter the Retainer Name");
    document.getElementById('txtretainername').disabled=false;
    document.getElementById('txtretainername').value="";
    document.getElementById('txtretainername').focus();
    return false;    
    }
}
} 

function  RetainerCommissionDetail()
{ 
if ((trim(document.getElementById('txtretainercode').value)!="")&&(document.getElementById('txtretainercode').value!=null))
    {
  for ( var index = 0; index < 200; index++ ) 
  { 
 
var RetCode= document.getElementById('txtretainercode').value;
	//var agencysubcode=document.getElementById('txtsagencycode').value;
    popUpWin1= window.open("RetainerCommDetails.aspx?show="+show+"&n_m="+saurabh+"&RetCode="+RetCode,"Commission","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
  popUpWin1.focus();
     return false;
  } 
  return false;
}
else
{
    if(document.getElementById('hiddenauto')==1)
    {
        alert("Please enter the Retainer Code");
    document.getElementById('txtretainercode').disabled=false;
    document.getElementById('txtretainercode').value="";
    document.getElementById('txtretainercode').focus();
    return false;
    }
    else
    {
    alert("Please enter the Retainer Name");
    document.getElementById('txtretainername').disabled=false;
    document.getElementById('txtretainername').value="";
    document.getElementById('txtretainername').focus();
    return false;    
    }
}
}  


function  RetainerPayMode()
{ 
if ((trim(document.getElementById('txtretainercode').value)!="")&&(document.getElementById('txtretainercode').value!=null))
    {
  for ( var index = 0; index < 200; index++ ) 
  { 
 
var RetPayCode= document.getElementById('txtretainercode').value;	//var agencysubcode=document.getElementById('txtsagencycode').value;
    popUpWin3= window.open("RetainerPaymode.aspx?show="+show+"&n_m="+saurabh+"&RetPayCode="+RetPayCode,"pay","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
  popUpWin3.focus();
     return false;
  } 
  return false;
}
else
{
    if(document.getElementById('hiddenauto')==1)
    {
        alert("Please enter the Retainer Code");
    document.getElementById('txtretainercode').disabled=false;
    document.getElementById('txtretainercode').value="";
    document.getElementById('txtretainercode').focus();
    return false;
    }
    else
    {
    alert("Please enter the Retainer Name");
    document.getElementById('txtretainername').disabled=false;
    document.getElementById('txtretainername').value="";
    document.getElementById('txtretainername').focus();
    return false;    
    }
}
} 

function RetExit()
{
if(confirm ("Do you want to Skip this page"))
	{
	
	if(typeof(popUpWin)!="undefined")
	{
	popUpWin.close();
	}
	if(typeof(popUpWin1)!="undefined")
	{
	popUpWin1.close();
	}
	if(typeof(popUpWin3)!="undefined")
	{
	popUpWin3.close();
	}
	
	//window.location.href='Enterpage.aspx';
	window.close();
	return false;
	
	}
	return false;

}



/*=================================================================================*/

//Paymode Coding

var mystatus;
//Retainer Pay Mode Submission

function PayModeSubmit()
{
	/*var chkList234= document.getElementById("rdolistSubmit");
		var l=document.getElementById("rdolistSubmit").rows.length;
		var MyArray = new Array(500);
		var str=new Array(3);;
		
	for(i=0;i<l;i++)
	{
	    MyArray[i]= document.getElementById ("rdolistSubmit_"+i).nextSibling;
	}
	MyArray[0]= document.getElementById ("rdolistSubmit_0").nextSibling;
	MyArray[1]= document.getElementById ("rdolistSubmit_1").nextSibling;
	MyArray[2]= document.getElementById ("rdolistSubmit_2").nextSibling;
	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
	
	var cot="false";
	
	for(i=0;i<l;i++)
	{	
		if(arrayOfCheckBoxes[i].checked==true)
		{
		    cot="true";
		    break;
		}
	}
	
	if(cot=="false")
	{
        alert('Please Check One Mode of Payment');
		return false;
	    
	}
	else
	{
	
		var compcode=document.getElementById('hiddencompcode').value;
		var retcode=document.getElementById('hiddenretcode').value; 
		var userid = document.getElementById('hiddenuserid').value; 
		
		for(var i=0;i<arrayOfCheckBoxes.length;i++)
		{
			if(arrayOfCheckBoxes[i].checked==true)
			{
			    //saurabh
			    
				str[i]=MyArray[i].innerHTML;
				
		        str=arrayOfCheckBoxes[i].value;
			}
		}
		
//		alert('Data Saved Successfully');
//		
//		return;
		
//		document.getElementById("rdolistsubmit").disabled=true;
//		document.getElementById("btnSubmit").disabled=true;
		
		var compcode=document.getElementById('hiddencompcode').value;
		var retcode=document.getElementById('hiddenretcode').value; 
		var userid = document.getElementById('hiddenuserid').value; 
		
		
		
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
RetainerPaymode.RetainerPayModeInsert(compcode,retcode,userid,str);
		
		alert('Data Saved Successfully');
		RetainerPayModeUpdatedData();
		arrayOfCheckBoxes[0].checked=false ;
		arrayOfCheckBoxes[1].checked=false ;
		arrayOfCheckBoxes[2].checked=false;
		document.getElementById("rdolistsubmit").disabled=true;
		document.getElementById("btnSubmit").disabled=true;
		mystatus=1;
	}
	chk123();	
	return false;*/
	
	var chkList234= document.getElementById("rdolistsubmit");
	var count_chk=0;
	var str;
	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
	for(var j=0;j<arrayOfCheckBoxes.length;j++)
	{
		if(arrayOfCheckBoxes[j].checked==true)
			{
			count_chk=1;
			break;
			}
			else
			{
			count_chk=0;
			}
	}
	if(count_chk==0)
	{
		alert('Please Check One Mode of Payment');
		return false;
	}
	else
	{
	
		var compcode=document.getElementById('hiddencompcode').value;
		var retcode=document.getElementById('hiddenretcode').value; 
		var userid = document.getElementById('hiddenuserid').value; 
		
		for(var i=0;i<arrayOfCheckBoxes.length;i++)
		{
			if(arrayOfCheckBoxes[i].checked==true)
			{
				
				str=arrayOfCheckBoxes[i].value;
		
			}
		}
		return;
		////dan
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
RetainerPaymode.RetainerPayModeInsert(compcode,retcode,userid,str);
		
		//alert('Data Saved Successfully');
		document.getElementById("rdolistsubmit").disabled=true;
		document.getElementById("btnSubmit").disabled=true;
	}
	   //chk123()
		return false;
}


//Client Refereshed Data

function RetainerPayModeUpdatedData()
{
	var chkListSubmit=document.getElementById("rdolistsubmit");
	//var chkListSubmit= document.getElementById("chklstSubmit");
	var arrayOfCheckBoxesSubmit= chkListSubmit.getElementsByTagName("input");
	
	//var chklstUpdate1= document.getElementById("chklstUpdate");
	
	var chklstUpdate1= document.getElementById("rdolistupdate");
	
	var arrayOfCheckBoxesUpdate= chklstUpdate1.getElementsByTagName("input");
	
	for(var i =0;i<=arrayOfCheckBoxesSubmit.length-1;i++)
	{
		if(arrayOfCheckBoxesSubmit[i].checked==true)
		{
			arrayOfCheckBoxesUpdate[i].checked=true;
		}
	}
	
	
	
	//document.getElementById('chklstUpdate').disabled=false;
	
	document.getElementById('rdolistupdate').disabled=false;
	
	document.getElementById("btnUpdate").disabled=false;
	return false;
}


//Updating Values 


function PayModeUpdate()
{
	//var chkList234= document.getElementById("chklstUpdate");
	
		var chkList234= document.getElementById("rdolistupdate");
		var count_chk=0;
		//var l=document.getElementById("rdolistSubmit").rows.length;
		var l=document.getElementById("rdolistupdate").rows.length;
	
	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
	
	var MyArray = new Array(500)
	//var str = new Array(3);
	var str;
//	MyArray[0]= document.getElementById ("chklstUpdate_0").nextSibling;
//	MyArray[1]= document.getElementById ("chklstUpdate_1").nextSibling;
//	MyArray[2]= document.getElementById ("chklstUpdate_2").nextSibling;
//	
//	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
		
	for(var j=0;j<arrayOfCheckBoxes.length;j++)
	{
		if(arrayOfCheckBoxes[j].checked==true)
			{
			count_chk=1;
			break;
			}
			else
			{
			count_chk=0;
			}
	}
	if(count_chk==0)
	{
		alert('Please Check One Mode of Payment');
		return false;
	}
	else
	{
	var compcode=document.getElementById('hiddencompcode').value;
		var retcode=document.getElementById('hiddenretcode').value; 
		var userid = document.getElementById('hiddenuserid').value; 
		
		for(var i=0;i<arrayOfCheckBoxes.length;i++)
		{
			if(arrayOfCheckBoxes[i].checked==true)
			{
				
				str=arrayOfCheckBoxes[i].value;
		
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
RetainerPaymode.RetainerPayModeInsert(compcode,retcode,userid,str);
		document.getElementById('btnUpdate').disabled=true; 
		//alert("Data saved");
	}
	return false;
}






/*=================================================================================*/


/*Retainer Commission details coding starts */


function DataGridBind()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	RetainerCommDetails.DatagridBind(retcode,compcode, userid,dateformat);
	return false;
}


var updatecommission = "";
var txtefffrom,txtefftill;



var controlstatus;
//Submit Button coding
function CommSubmit()
{
	var fromdate=document.getElementById('txtefffrom').value;
	var todate=document.getElementById('txtefftill').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var txtcommrate = document.getElementById('txtcommrate').value;
	var txtaddcommrate = document.getElementById('txtaddcommrate').value;
	var discount = document.getElementById('drpcommdetail').value;
	
	var updatecommission=document.getElementById('hiddenccode').value;
	
	var txtframt = trim(document.getElementById('txtframt').value);
	var txttoamt = trim(document.getElementById('txttoamt').value);
	  if(document.getElementById('txtframt').value!="")
     {
			    if(txtframt.match(/^\d+(\.\d{1,3})?$/i))
			    {
			      //return true;
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById('txtframt').value="";
			        return false;
			    }
    }
   if(document.getElementById('txttoamt').value!="")
     {
			    if(txttoamt.match(/^\d+(\.\d{1,3})?$/i))
			    {
			     // return true;
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById('txttoamt').value="";
			        return false;
			    }
    }
	if(parseFloat(txtframt)>parseFloat(txttoamt))
	 {
	   alert("From Amt cannot be greater than To Amt.");
	   document.getElementById('txtframt').value="";
	   document.getElementById('txttoamt').value="";
	   return false;
	 }
//	else
//	  alert("From Amt cannot be greater than To Amt.");
	if(dateformat=="mm/dd/yyyy")
		{
		var txtefffrom=document.getElementById('txtefffrom').value;
	    var txtefftill=document.getElementById('txtefftill').value;
		}
		
		if(dateformat=="dd/mm/yyyy")
		{
			var txtfrom=fromdate.split("/");
			var ddfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var yyfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var ddtill=txttill[0];
			var mmtill=txttill[1];
			var yytill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtfrom=fromdate.split("/");
			var yyfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var ddfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var yytill=txttill[0];
			var mmtill=txttill[1];
			var ddtill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
	var fdate=new Date(txtefffrom);
	var tdate=new Date(txtefftill);

    var bc=document.getElementById('lblefffrom').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtefffrom').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtefffrom').focus();
	            return false;
	        }
	    }
	    
	bc=document.getElementById('lblcommrate').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtcommrate').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtcommrate').focus();
	            return false;
	        }
	    }
	
	bc=document.getElementById('lblefftill').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtefftill').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtefftill').focus();
	            return false;
	        }
	    }
	    
	    bc=document.getElementById('lblcommapplyon').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('drpcommdetail').value)== "0" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('drpcommdetail').focus();
	            return false;
	        }
	    }
	    
    
	if(fromdate !='' && todate !='' && fdate > tdate)
	{
		alert("Effective To Date Must Be Greater Than Effective From Date");
		document.getElementById('txtefftill').focus();
		return false;
	}					
	else if(fdate > tdate)
	{
	alert("Effective Till Date Should be Greater Then From Date");
	return false;
	}

	if(parseFloat(document.getElementById('txtcommrate').value)>100)
	{
	    alert('Commition rate should be less than 100');
	    document.getElementById('txtcommrate').value="";
	    document.getElementById('txtcommrate').focus();
	    return false;
	}
	//--------------------- check double dot ------------------------//
	 if(document.getElementById('txtcommrate').value!="")
     {
			    if(txtcommrate.match(/^\d+(\.\d{1,3})?$/i))
			    {
			      //return true;
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById('txtcommrate').value="";
			        return false;
			    }
    }
    if(document.getElementById('txtaddcommrate').value!="")
     {
			    if(txtaddcommrate.match(/^\d+(\.\d{1,3})?$/i))
			    {
			     // return true;
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById('txtaddcommrate').value="";
			        return false;
			    }
    }
   
	//---------------------------------------------------------------//
	
	//***********************Duplicate Date Entry Cheching***************************************************

    var hidfdate=document.getElementById('hiddenfdate').value;
    var hidtdate=document.getElementById('hiddentdate').value;
    if(hidfdate!="")
    {
        var arrfdate=hidfdate.split(",");
        var arrtdate=hidtdate.split(",");
        for(var a=0;a<arrfdate.length;a++)
        {
            var fdate=arrfdate[a].split("/");
            var fday=fdate[1];
            var fmonth=fdate[0];
            var fyear=fdate[2];			        
            
            var txtfdatev=document.getElementById('txtefffrom').value;
            var txtfdate=txtfdatev.split("/");
            var txtfday=txtfdate[1];
            var txtfmonth=txtfdate[0];
            var txtfyear=txtfdate[2];
            
            var tdate=arrtdate[a].split("/");
            var tday=tdate[1];
            var tmonth=tdate[0];
            var tyear=tdate[2];			        
            
            var txttdatev=document.getElementById('txtefftill').value;
            var txttdate=txttdatev.split("/");
            var txttday=txttdate[1];
            var txttmonth=txttdate[0];
            var txttyear=txttdate[2];
            
//            if(((txtfyear>=fyear) && (txtfyear<=tyear)) || ((txttyear>=fyear) && (txttyear<=tyear)))
//            {
//                if(((txtfmonth>=fmonth) && (txtfmonth<=tmonth)) || ((txttmonth>=fmonth) && (txttmonth<=tmonth)))
//                {
//                    if(((txtfday>=fday) && (txtfday<=tday)) || ((txttday>=fday) && (txttday<=tday)))
//                    {
//                        if( )
//                        {
//                            alert("This date is already assigned");
//                            return false;
//                        }
//                    }
//                }
//            }
         }
     }
//--------------------------------------------------------------------------------------------------------------//	
	    var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;	
		var codepass=document.getElementById('hiddenccode').value;
		//this function will check the date validity
		
		//bhattar
		
//		if(updatecommission==null||updatecommission=="")
//		{
//		RetainerCommDetails.chkcommdate(retcode,userid,compcode,txtefffrom,txtefftill,chkdate_CallBackinsert);
//		}
//		else
//		{
//		RetainerCommDetails.chkcommdateupdate(retcode,userid,compcode,txtefffrom,txtefftill,codeid,chkdate_CallBackupdate);
//		}
//	}

//	return false;	
//}


//if(modify!="1")
//{

if(document.getElementById("hiddenshow").value=="2")
{
   var dl;   
     if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkretcom.aspx?retcode="+retcode+"&dateformat="+dateformat+"&fdate="+txtefffrom+"&tdate="+txtefftill+"&codepass="+updatecommission+"&txtframt="+txtframt+"&txttoamt="+txttoamt, false );
                        httpRequest.send('');
                        dl = httpRequest.responseText;
                     
                   
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
                                
                            }
                           else 
                            {
                                alert('Session Expired.Please Login Again.');
                                return false;
                            }
                        }
                    }

 else
 {
 
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","chkretcom.aspx?retcode="+retcode+"&dateformat="+dateformat+"&fdate="+txtefffrom+"&tdate="+txtefftill+"&codepass="+updatecommission+"&txtframt="+txtframt+"&txttoamt="+txttoamt, false );
            xml.Send();
            var dl=xml.responseText;
}
           if(dl=="yes")
            {
                 alert('Session Expired.Please Login Again.');
                return false;
            }
            
            if(dl=="Y")
            {
               alert("This date is already assigned");
    	        return false;
    	    }
//	      
	       else
	       {
alert(opener.document.getElementById('hiddenchk').value)
alert(flag2)
                if  (opener.document.getElementById('hiddenchk').value=="1")
                {
                    if(flag2=="1")
                    {
                       // pubstatdetails.updatepcm(compcode,userid,centcode,status,circular,todate,fromdate,dateformat,codepass,updatepcmcall);
//                     RetainerStatusMaster.checkstatusdateupdate(retcode,compcode,userid,status,circular,todate,fromdate,codepass);
                       RetainerCommDetails.RetainerCommission(retcode,userid,compcode,txtefffrom,txtefftill,txtcommrate,discount,updatecommission,1,txtframt,txttoamt,txtaddcommrate);
                       window.location=window.location;
				        return false;
				    }
				    else
				    {
//				        pubstatdetails.insertpcm(compcode,userid,centcode,status,circular,todate,fromdate,dateformat,insertpcmcall);
                        
//                        RetainerStatusMaster.insertretstatus(compcode,userid,retcode,status,circular,todate,fromdate,dateformat,insertretstatuscall);
                        RetainerCommDetails.RetainerCommission(retcode,userid,compcode,txtefffrom,txtefftill,txtcommrate,discount,updatecommission,0,txtframt,txttoamt,txtaddcommrate);
                        window.location=window.location;
				        return false;
				    }
                }
                else
                {
			        return ;
                }
                
           }
     }

	else
	{
//           RetainerCommDetails.RetainerCommission(retcode,userid,compcode,txtefffrom,txtefftill,txtcommrate,discount,updatecommission,1,txtframt,txttoamt);
//           window.location=window.location;
			return;
	}

}



//After date ,will insert records according to the values
function chkdate_CallBack(response)
{
	var ds = response.value;
	if(ds.Tables[0].Rows.length>0)
	{
		alert("Your Date Selected has Already been Assigned !!!Please Select Different Date ");
		return false;
	}
	else
	{
		var txtcommrate=document.getElementById('txtcommrate').value;
		var discount=document.getElementById('drpcommdetail').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = trim(document.getElementById('hiddenretcode').value);
		var fromdate=document.getElementById('txtefffrom').value;
	var todate=document.getElementById('txtefftill').value;
	var dateformat = document.getElementById('hiddendateformat').value;
		if(dateformat=="mm/dd/yyyy")
		{
		var txtefffrom=document.getElementById('txtefffrom').value;
	var txtefftill=document.getElementById('txtefftill').value;
		}
		
		if(dateformat=="dd/mm/yyyy")
		{
			var txtfrom=fromdate.split("/");
			var ddfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var yyfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var ddtill=txttill[0];
			var mmtill=txttill[1];
			var yytill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtfrom=fromdate.split("/");
			var yyfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var ddfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var yytill=txttill[0];
			var mmtill=txttill[1];
			var ddtill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
		
		if(updatecommission==null||updatecommission=="")
		{
			//Insert the records
			RetainerCommDetails.RetainerCommission(retcode,userid,compcode,txtefffrom,txtefftill,txtcommrate,discount,updatecommission,0);
		}
		else
		{
			//Update the Records
			RetainerCommDetails.RetainerCommission(retcode,userid,compcode,txtefffrom,txtefftill,txtcommrate,discount,updatecommission,1);
		}
	}
	window.location=window.location;
	return false;
}



//Select the values from datagrid
function CommSelect()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;

	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	
		if(document.getElementById(str).checked==true)
		{
			k=k+1;
			codeid=document.getElementById(str).value;
		}
	}
	if(k==1)
	{
		document.getElementById('btndelete').disabled=false; 
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
RetainerCommDetails.GetRetComm(compcode,userid,retcode,codeid,0,Select_CallBack);
		return false;
		
	}
	else
	{
		alert("You Can Select One Row At A Time");
		return false;
	}
	return false;
}


//function callback to fill the values to the controls
function Select_CallBack(response)
{
	var ds = response.value;
	if(ds.Tables[0].Rows.length>0)
	{
		var dateformat = document.getElementById('hiddendateformat').value;
		
		var txteffrom = ds.Tables[0].Rows[0].Eff_from_date;
		var txtefftill = ds.Tables[0].Rows[0].Eff_Till_date;
		var ddfrom = txteffrom.getDate();
		var mmfrom = txteffrom.getMonth() + 1;
		var yyyyfrom = txteffrom.getFullYear();
		var ddtill = txtefftill.getDate();
		var mmtill = txtefftill.getMonth() + 1;
		var yyyytill = txtefftill.getFullYear();
		
		if(dateformat=="dd/mm/yyyy")
		{
			txteffrom=ddfrom+'/'+mmfrom +'/'+yyyyfrom ;
			txtefftill=ddtill+'/'+mmtill+'/'+yyyytill;
			
		}
		else if(dateformat=="yyyy/mm/dd")
		{
			txteffrom=yyyyfrom +'/'+mmfrom +'/'+ddfrom ;
			txtefftill=yyyytill+'/'+mmtill+'/'+ddtill;
		}
		else
		{
			txteffrom=mmfrom +'/'+ddfrom +'/'+yyyyfrom ;
			txtefftill=mmtill+'/'+ddtill+'/'+yyyytill;
		}
				
		updatecommission = ds.Tables[0].Rows[0].Comm_Code;
		document.getElementById('txtcommrate').value=ds.Tables[0].Rows[0].Comm_rate;
		document.getElementById('drpcommdetail').value=ds.Tables[0].Rows[0].Discount;
		document.getElementById('txtefffrom').value = txteffrom;
		document.getElementById('txtefftill').value = txtefftill;
		
		document.getElementById('txtframt').value = ds.Tables[0].Rows[0].FROMAMOUNT;
		document.getElementById('txttoamt').value = ds.Tables[0].Rows[0].TOAMOUNT;
		if(ds.Tables[0].Rows[0].Addl_Comm_Rate!=null)
		{
		    document.getElementById('txtaddcommrate').value = ds.Tables[0].Rows[0].Addl_Comm_Rate;
		}    
		
	}
	else
	{
		alert("Please Click the Checkbox");
		return false;
	}
	return false;
}



//Clear the values
function CommClear()
{
	document.getElementById('txtefffrom').value="";
	document.getElementById('txtefftill').value="";
	document.getElementById('txtcommrate').value="";
	document.getElementById('drpcommdetail').value="0";
	return false;
}

//Delete the records 

function CommDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var update=document.getElementById('hiddenccode').value; 

	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
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
RetainerCommDetails.GetRetComm(compcode,userid,retcode,update,1);
		
		
		  document.getElementById('txtefffrom').value="";
       document.getElementById('txtefftill').value="";
       document.getElementById('drpcommdetail').value="0";
       document.getElementById('txtcommrate').value="";
       document.getElementById('hiddenccode').value="";
       //alert(xmlObj.childNodes(0).childNodes(2).text);
       //alert('Data Deleted Successfully');
       
       window.location=window.location;

//	for(j=0;j<i;j++)
//	{
//		var str="DataGrid1__ctl_CheckBox1"+j;
//	
//		if(document.getElementById(str).checked==true)
//		{
//			k=k+1;
//		}
//	}
//	if(k==1)
//	{
		
//		return false;	
//	}
//	else
//	{
//		alert("You Can Select One Row At A Time");
//		return false;
//	}
	return false;	
}

/*Retainer Commission details coding Ends */

/*===============================================================================*/


/*Retainer Status Detail Coding Starts*/


var txtfrom,txtto;
var updatestatus="";
var codestatusid="";

//===============================saurabh=====================================================

function RetStatusSubmit()
{
    var status=document.getElementById('drpstatus').value;
	var fromdate=document.getElementById('txtfrom').value;
	var todate=document.getElementById('txtto').value;
	
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var updatecommission=document.getElementById('hiddenccode').value;
	var codepass=document.getElementById('hiddenccode').value;
	
	if(dateformat=="mm/dd/yyyy")
	{
        var fromdate=document.getElementById('txtfrom').value;
        var todate=document.getElementById('txtto').value;
	}
		
	if(dateformat=="dd/mm/yyyy")
	{
		var txtfrom=fromdate.split("/");
		var ddfrom=txtfrom[0];
		var mmfrom=txtfrom[1];
		var yyfrom=txtfrom[2];
		fromdate=mmfrom+'/'+ddfrom+'/'+yyfrom;
		
		var txttill=todate.split("/");
		var ddtill=txttill[0];
		var mmtill=txttill[1];
		var yytill=txttill[2];
		todate=mmtill+'/'+ddtill+'/'+yytill;
	}
	if(dateformat=="yyyy/mm/dd")
	{
		var txtfrom=fromdate.split("/");
		var yyfrom=txtfrom[0];
		var mmfrom=txtfrom[1];
		var ddfrom=txtfrom[2];
		fromdate=mmfrom+'/'+ddfrom+'/'+yyfrom;
		
		var txttill=todate.split("/");
		var yytill=txttill[0];
		var mmtill=txttill[1];
		var ddtill=txttill[2];
		todate=mmtill+'/'+ddtill+'/'+yytill;
	}
	
	var fdate=new Date(fromdate);
	var tdate=new Date(todate);
if(browser!="Microsoft Internet Explorer")
                        {
                           var dc=document.getElementById('lblfromdate').textContent;
                        }
                        else
                        {
    var dc=document.getElementById('lblfromdate').innerText;
  }
   if(dc.indexOf('*')>=0)
    {
	    if (trim(document.getElementById('txtfrom').value)=="")
	    {
		    alert('Plese Enter '+(dc.replace('*',"")));
		    document.getElementById('txtfrom').focus();
	        return false;
	    }
	}	
	if(browser!="Microsoft Internet Explorer")
                        {
                           var dc=document.getElementById('lblstatus').textContent;
                        }
                        else
                        {
	dc=document.getElementById('lblstatus').innerText;
	}
   if(dc.indexOf('*')>=0)
    {
	    if (document.getElementById('drpstatus').value=="0" || document.getElementById('drpstatus').value=="")
	    {
		    alert('Plese Enter '+(dc.replace('*',"")));
		    document.getElementById('drpstatus').focus();
		    return false;
	    }
	}
	if(browser!="Microsoft Internet Explorer")
                        {
                           var dc=document.getElementById('lbltodate').textContent;
                        }
                        else
                        {
	dc=document.getElementById('lbltodate').innerText;
	}

    if(dc.indexOf('*')>=0)
    {
	    if (trim(document.getElementById('txtto').value)=="")
	    {
		    alert('Plese Enter '+(dc.replace('*',"")));
		    document.getElementById('txtto').focus();
		    return false;
	    }
	}
	
	if(fromdate !='' && todate !='' && fdate > tdate)
	{
		alert("To Date Must Be Greater Than From Date");
		document.getElementById('txtto').focus();
		return false;
	}					
    else if(fdate > tdate)
	{
	alert("From Date Should Be Less Than To Date");
	return false;
	}
	
	
        var circular=document.getElementById('txtcircularno').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;   
		
	
		if(browser!="Microsoft Internet Explorer")
                        {
                           var dc=document.getElementById('lblcircular').textContent;
                        }
                        else
                        {
	dc=document.getElementById('lblcircular').innerText;
	}

    if(dc.indexOf('*')>=0)
    {
	    if (trim(document.getElementById('txtcircularno').value)=="")
	    {
		    alert('Plese Enter '+(dc.replace('*',"")));
		    document.getElementById('txtcircularno').focus();
		    return false;
	    }
	}
	
//***********************Duplicate Date Entry Cheching***************************************************

    var hidfdate=document.getElementById('hiddenfdate').value;
    var hidtdate=document.getElementById('hiddentdate').value;
    if(hidfdate!="")
    {
        var arrfdate=hidfdate.split(",");
        var arrtdate=hidtdate.split(",");
        for(var a=0;a<arrfdate.length;a++)
        {
            var fdate=arrfdate[a].split("/");
            var fday=fdate[1];
            var fmonth=fdate[0];
            var fyear=fdate[2];			        
            
            var txtfdatev=document.getElementById('txtfrom').value;
            var txtfdate=txtfdatev.split("/");
            var txtfday=txtfdate[1];
            var txtfmonth=txtfdate[0];
            var txtfyear=txtfdate[2];
            
            var tdate=arrtdate[a].split("/");
            var tday=tdate[1];
            var tmonth=tdate[0];
            var tyear=tdate[2];			        
            
            var txttdatev=document.getElementById('txtto').value;
            var txttdate=txttdatev.split("/");
            var txttday=txttdate[1];
            var txttmonth=txttdate[0];
            var txttyear=txttdate[2];
            
            if(((txtfyear>=fyear) && (txtfyear<=tyear)) || ((txttyear>=fyear) && (txttyear<=tyear)))
            {
                if(((txtfmonth>=fmonth) && (txtfmonth<=tmonth)) || ((txttmonth>=fmonth) && (txttmonth<=tmonth)))
                {
                    if(((txtfday>=fday) && (txtfday<=tday)) || ((txttday>=fday) && (txttday<=tday)))
                    {
                        alert("This date is already assigned");
                        return false;
                    }
                }
            }
         }
     }
//--------------------------------------------------------------------------------------------------------------//	
		// Hidden fields for final save event
		
	opener.document.getElementById('hidden1s').value=status;
    opener.document.getElementById('hidden2s').value=circular;
    opener.document.getElementById('hidden3s').value=fromdate;
	opener.document.getElementById('hidden4s').value=todate;
		
		
		
		//*************************************************************************
		//                          Start from here
		//*************************************************************************
	
if(document.getElementById("hiddenshow").value=="2")
{
		  var dl     
if(browser!="Microsoft Internet Explorer")
                    {
                      var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","chkretstatus.aspx?retcode="+retcode+"&status="+status+"&dateformat="+dateformat+"&fdate="+fromdate+"&tdate="+todate+"&circular="+circular+"&codepass="+codepass, false );
                        httpRequest.send('');
                       dl= httpRequest.readyState 
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
                               alert('Session Expired Please Login Again.');
                            }
                        }
                    }
               else
               {
		    var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open( "GET","chkretstatus.aspx?retcode="+retcode+"&status="+status+"&dateformat="+dateformat+"&fdate="+fromdate+"&tdate="+todate+"&circular="+circular+"&codepass="+codepass, false );
		             xml.Send();
		            dl=xml.responseText;
		            if(dl=="yes")
		            {
		                 alert('Session Expired.Please Login Again.');
                        return false;
		            }
		            }
		            
		              if(dl=="Y")
		                {
    		
		                alert("This date is already assigned");
	            	    return false;

	                	}
	        	    else
	        	    {

                        if  (opener.document.getElementById('hiddenchk').value=="1")
                        {
                            if(flag2=="1")
                           {
                               // pubstatdetails.updatepcm(compcode,userid,centcode,status,circular,todate,fromdate,dateformat,codepass,updatepcmcall);
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
RetainerStatusMaster.checkstatusdateupdate(retcode,compcode,userid,status,circular,todate,fromdate,codepass);
                               window.location=window.location;
				                return false;
				          }
				         else
				         {
                            codepass="";
                            RetainerStatusMaster.insertretstatus(compcode,userid,retcode,status,circular,todate,fromdate,dateformat,codepass,insertretstatuscall);
                           //window.location=window.location;
                            return false;
				         }
                       }
                        else
                        {
	                        return ;
                        }
                    }

            
      }
		else
			{

				return;// false;
			}
}


//////////////////////////////////////////////////////////////////////////////////////////////

//call back reponse of insert operation of Retainer Status Detail

function insertretstatuscall(response)
{

var ds=response.value;
if (ds=="fail")
{
	alert("This date has been already assigned");
	return false;

}

else
{

//*********************************

var status=document.getElementById('drpstatus').value;
	var fromdate=document.getElementById('txtfrom').value;
var todate=document.getElementById('txtto').value;
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var circular=document.getElementById('txtcircularno').value;
//		var compcode = document.getElementById('hiddencompcode').value;
//		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;  

//*********************************

//var compcode=document.getElementById('hiddencompcode').value;
//var userid=document.getElementById('hiddenuserid').value;
//var centcode =document.getElementById('hiddencentcode').value;
//var status=document.getElementById('drpstatus').value;
//var dateformat=document.getElementById('hiddendateformat').value;
//var circular=document.getElementById('txtCircular').value;

	var fromdate,todate;		

		if(trim(document.getElementById('txtfrom').value)=="")
					{
						alert("Please enter from date");
						document.getElementById('txtfrom').value="";
						document.getElementById('txtfrom').focus();
						return false;
					}
		else if(document.getElementById('drpstatus').value=="0")
					{
						alert("Please Select Status");
						document.getElementById('drpstatus').focus();
						return false;
					}
			else if(trim(document.getElementById('txtto').value)=="")
			{
				alert("Please enter to date");
				document.getElementById('txtfrom').value="";
				document.getElementById('txtto').focus();
				return false;
			}  


			if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=document.getElementById('txtfrom').value;
				}
		
			else if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						fromdate=document.getElementById('txtfrom').value;
					}


	/*===========================todate===================*/


			if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
			if(dateformat=="mm/dd/yyyy")
				{
					todate=document.getElementById('txtto').value;
				}
					
			if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					alert("dateformat  is either null or undefined");
					todate=document.getElementById('txtto').value;
				}


				var fdate=new Date(fromdate);
				var tdate=new Date(todate);

		
			if( fdate > tdate)
					{
						alert("To date must be greater then from date");
						return false;
					}
	

        RetainerStatusMaster.insertretstatus12(compcode,userid,retcode,status,fromdate,todate,circular);
        
       window.location=window.location
       // return false;

}

}


////////////////////////////////////////////////////////////////////////////////////////////////


//Status Submit
function StatusSubmit()
{
	//checkdate('txtfrom');
	//checkdate('txtto');
	var status=document.getElementById('drpstatus').value;
	var fromdate=document.getElementById('txtfrom').value;
	var todate=document.getElementById('txtto').value;
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var fdate=new Date(fromdate);
	var tdate=new Date(todate);

	if (document.getElementById('txtfrom').value=="")
	{
		alert("Plese Fill Effective From Date");
		return false;
	}	
	else if (document.getElementById('txtto').value=="")
	{
		alert("Plese Fill Effective Till Date");
		return false;
	}	 
	else if(fromdate !='' && todate !='' && fdate > tdate)
	{
		alert("Till Date Must Be Greater Than From Date");
		document.getElementById('txtto').focus();
		return false;
	}					
	else if(document.getElementById('txtcircularno').value=="")
	{
		alert(" Please Fill The Circular Number ");
		document.getElementById('txtcircularno').focus();
		return false;
	}
	else if(document.getElementById('drpstatus').value=="0")
	{
		alert("Please Select Status");
		document.getElementById('drpstatus').focus();
		return false;
	}
	else if(fdate > tdate)
	{
	alert("From Date Should Be Less Then To Date");
	return false;
	}
	else
	{

		if(dateformat=="dd/mm/yyyy")
		{
			var txtstatusfrom=fromdate.split("/");
			var ddfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var yyfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var ddtill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var yytill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtstatusfrom=fromdate.split("/");
			var yyfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var ddfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var yytill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var ddtill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;
		
		//this function will check the date validity
		if(codestatusid==null||codestatusid=="")
		{
		RetainerStatusMaster.checkstatusdate(retcode,compcode, userid,dateformat,fromdate,todate,1,chkStatusdate_CallBackinsert);
		}
		else
		{
		RetainerStatusMaster.checkstatusdateupdate(retcode,compcode, userid,dateformat,fromdate,todate,codestatusid,chkStatusdate_CallBackupdate);
		}
		
		return false;
	}
	return false;	
}



//After date ,will insert records according to the values
function chkStatusdate_CallBack(response)
{
	var ds = response.value;
	if(ds.Tables[0].Rows.length>0)
	{
		alert("Your Date Selected has Already been Assigned !!!Please Select Different Date ");
		return false;
	}
	else
	{
		var circular=document.getElementById('txtcircularno').value;
		var status=document.getElementById('drpstatus').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;
		var dateformat = document.getElementById('hiddendateformat').value;
		var fromdate=document.getElementById('txtfrom').value;
	var todate=document.getElementById('txtto').value;
	
	if(dateformat=="mm/dd/yyyy")
	{
	var txtfrom=document.getElementById('txtfrom').value;
	var txtto=document.getElementById('txtto').value;
	}
		
		if(dateformat=="dd/mm/yyyy")
		{
			var txtstatusfrom=fromdate.split("/");
			var ddfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var yyfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var ddtill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var yytill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtstatusfrom=fromdate.split("/");
			var yyfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var ddfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var yytill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var ddtill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		
		if(updatestatus==null||updatestatus=="")
		{
			//Insert the records
			RetainerStatusMaster.Ret_StatusOperation(userid,compcode,retcode,status,txtfrom,txtto,circular,codestatusid,0);
			window.location=window.location;
			return false;
		}
		else
		{
			//Update the Records
			RetainerStatusMaster.Ret_StatusOperation(userid,compcode,retcode,status,txtfrom,txtto,circular,codestatusid,1);
			window.location=window.location;
			return false;
		}
	}
	window.location=window.location;
	return false;
}


//Status select value from Datagrid
function StatusSelect(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpstatus').value="0";
       document.getElementById('txtCircularno').value="";
       if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSubmit').disabled=true;
       }
//       else
//       {
//            document.getElementById('btnSubmit').disabled=false;
//       }
       document.getElementById('btndelete').disabled=true;
       document.getElementById(ab).checked=false;
       return;// false;
        
    }
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	
	    document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;
// saurabh change    
    if(document.getElementById('hiddendelsau').value=="1")
	{
   document.getElementById('btndelete').disabled= false;
    }

    if(id==str)
        {
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	code11=document.getElementById(str).value;
	chkclick=document.getElementById(id);
	
	//saurabh change
	
	if(document.getElementById('hiddendelsau').value=="1")
	{
	document.getElementById('btndelete').disabled= false;
    }
	
	}
	}
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}
//	else
//	{
//		document.getElementById('btndelete').disabled=false;
//	
//	}
	RetainerStatusMaster.bandstatus(retcode,compcode,userid,code11,dateformat,SelectStatus_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
       document.getElementById('txtfrom').value="";
document.getElementById('txtto').value="";
document.getElementById('drpstatus').value="0";
document.getElementById('txtcircularno').value="";
          
	return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnSubmit').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	
}



//function callback to fill the values to the controls
function SelectStatus_CallBack(response)
{
	var ds = response.value;
//	if(ds.Tables[0].Rows.length>0)
//	{
//		var dateformat = document.getElementById('hiddendateformat').value;
//		
//		var fromdate1 = ds.Tables[0].Rows[0].From_date;
//		var todate1 = ds.Tables[0].Rows[0].to_date;
//		var ddfrom = fromdate1.getDate();
//		var mmfrom = fromdate1.getMonth()+ 1;
//		var yyyyfrom = fromdate1.getFullYear();
//		var ddtill = todate1.getDate();
//		var mmtill = todate1.getMonth() + 1;
//		var yyyytill = todate1.getFullYear();
//		
//		if(dateformat=="dd/mm/yyyy")
//		{
//			txtfrom=ddfrom+'/'+mmfrom +'/'+yyyyfrom ;
//			txtto=ddtill+'/'+mmtill+'/'+yyyytill;
//			
//		}
//		else if(dateformat=="yyyy/mm/dd")
//		{
//			txtfrom=yyyyfrom +'/'+mmfrom +'/'+ddfrom ;
//			txtto=yyyytill+'/'+mmtill+'/'+ddtill;
//		}
//		else
//		{
//			txtfrom=mmfrom +'/'+ddfrom +'/'+yyyyfrom ;
//			txtto=mmtill+'/'+ddtill+'/'+yyyytill;
//		}
				
		updatecommission = ds.Tables[0].Rows[0].stat_code;
		if(ds.Tables[0].Rows[0].circular_no!=null)
		{
		document.getElementById('txtcircularno').value=ds.Tables[0].Rows[0].circular_no;
		}
		else
		{
		document.getElementById('txtcircularno').value="";
		}
		document.getElementById('drpstatus').value=ds.Tables[0].Rows[0].status_name;
		document.getElementById('txtfrom').value = ds.Tables[0].Rows[0].From_date;
		document.getElementById('txtto').value = ds.Tables[0].Rows[0].to_date;
		document.getElementById('hiddenccode').value = ds.Tables[0].Rows[0].stat_code;
		
//	}
//	else
//	{
//		alert("Please Click the Checkbox");
//		return false;
//	}
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSubmit').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnSubmit').disabled=false;
	}
	
	return false;
}



//Status Clear Values
function StatusClear()
{
    flag2="0";
	document.getElementById('txtfrom').value = "";
	document.getElementById('txtto').value = "";
	document.getElementById('txtcircularno').value = "";
	document.getElementById('drpstatus').value = "0";
	
	if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSubmit').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSubmit').disabled==false)))
{

var j;
var k=0;

var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	document.getElementById('btndelete').disabled=true;
	 if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSubmit').disabled=true;
       }
       else
       {
            document.getElementById('btnSubmit').disabled=false;
       }
	//document.getElementById('btnsubmit').disabled=true;
	}
}
	
	return false;
}

//Status delete
function StatusDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
    var update=document.getElementById('hiddenccode').value; 
 //var statusname=document.getElementById('drpstatus').value;
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;

//	for(j=0;j<i;j++)
//	{
//		var str="DataGrid1__ctl_CheckBox1"+j;
//	
//		if(document.getElementById(str).checked==true)
//		{
//			k=k+1;
//		}
//	}
//	if(k==1)
//	{
//	RetainerStatusMaster.Ret_StatusOperation(userid,compcode,retcode,status,"","","",codestatusid,2);

	RetainerStatusMaster.Ret_StatusOperation(userid,compcode,retcode,"","","","",update,2);
	//RetainerStatusMaster.Ret_StatusOperation(userid,compcode,retcode,update,2);
	   document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpstatus').value="0";
       document.getElementById('txtcircularno').value="";
       document.getElementById('hiddenccode').value="";	
		
		//alert('Data Deleted Successfully');
		
		//alert(xmlObj.childNodes(0).childNodes(2).text);
		
		window.location=window.location;
		
//		return false;
//	}
//	else
//	{
//		alert("You Can Select One Row At A Time");
//		return false;
//	}
	return false;	
}

/*Retainer Status Detail Coding ends*/

function chkdate_CallBackinsert(response)

{
var ds = response.value;
	if(ds.Tables[0].Rows.length>0)
	{
		alert("Your Date Selected has Already been Assigned !!!Please Select Different Date ");
		return false;
	}
	else
	{
		var txtcommrate=document.getElementById('txtcommrate').value;
		var discount=document.getElementById('drpcommdetail').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;
		var fromdate=document.getElementById('txtefffrom').value;
	var todate=document.getElementById('txtefftill').value;
	var dateformat = document.getElementById('hiddendateformat').value;
		if(dateformat=="mm/dd/yyyy")
		{
		var txtefffrom=document.getElementById('txtefffrom').value;
	var txtefftill=document.getElementById('txtefftill').value;
		}
		
		if(dateformat=="dd/mm/yyyy")
		{
			var txtfrom=fromdate.split("/");
			var ddfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var yyfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var ddtill=txttill[0];
			var mmtill=txttill[1];
			var yytill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtfrom=fromdate.split("/");
			var yyfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var ddfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var yytill=txttill[0];
			var mmtill=txttill[1];
			var ddtill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
		
		
			//Insert the records
			RetainerCommDetails.RetainerCommission(retcode,userid,compcode,txtefffrom,txtefftill,txtcommrate,discount,updatecommission,0);
		}		
			window.location=window.location;
			return false;

}

function chkdate_CallBackupdate(response)

{
var ds = response.value;
	if(ds.Tables[0].Rows.length>0)
	{
		alert("Your Date Selected has Already been Assigned !!!Please Select Different Date ");
		return false;
	}
	else
	{
		var txtcommrate=document.getElementById('txtcommrate').value;
		var discount=document.getElementById('drpcommdetail').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;
		var fromdate=document.getElementById('txtefffrom').value;
	var todate=document.getElementById('txtefftill').value;
	var dateformat = document.getElementById('hiddendateformat').value;
		if(dateformat=="mm/dd/yyyy")
		{
		var txtefffrom=document.getElementById('txtefffrom').value;
	var txtefftill=document.getElementById('txtefftill').value;
		}
		
		if(dateformat=="dd/mm/yyyy")
		{
			var txtfrom=fromdate.split("/");
			var ddfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var yyfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var ddtill=txttill[0];
			var mmtill=txttill[1];
			var yytill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtfrom=fromdate.split("/");
			var yyfrom=txtfrom[0];
			var mmfrom=txtfrom[1];
			var ddfrom=txtfrom[2];
			txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txttill=todate.split("/");
			var yytill=txttill[0];
			var mmtill=txttill[1];
			var ddtill=txttill[2];
			txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		}
		
		
			//Update the Records
			RetainerCommDetails.RetainerCommission(retcode,userid,compcode,txtefffrom,txtefftill,txtcommrate,discount,updatecommission,1);
		
	}
	window.location=window.location;
	return false;

}

function chkStatusdate_CallBackinsert(response)
{
var ds = response.value;
	if(ds.Tables[0].Rows.length>0)
	{
		alert("Your Date Selected has Already been Assigned !!!Please Select Different Date ");
		return false;
	}
	else
	{
		var circular=document.getElementById('txtcircularno').value;
		var status=document.getElementById('drpstatus').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;
		var dateformat = document.getElementById('hiddendateformat').value;
		var fromdate=document.getElementById('txtfrom').value;
	var todate=document.getElementById('txtto').value;
	
	if(dateformat=="mm/dd/yyyy")
	{
	var txtfrom=document.getElementById('txtfrom').value;
	var txtto=document.getElementById('txtto').value;
	}
		
		if(dateformat=="dd/mm/yyyy")
		{
			var txtstatusfrom=fromdate.split("/");
			var ddfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var yyfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var ddtill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var yytill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtstatusfrom=fromdate.split("/");
			var yyfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var ddfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var yytill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var ddtill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		
		
			//Insert the records
			RetainerStatusMaster.Ret_StatusOperation(userid,compcode,retcode,status,txtfrom,txtto,circular,codestatusid,0);
	}
			window.location=window.location;
			return false;
		

}

function chkStatusdate_CallBackupdate(response)
{
var ds = response.value;
	if(ds.Tables[0].Rows.length>0)
	{
		alert("Your Date Selected has Already been Assigned !!!Please Select Different Date ");
		return false;
	}
	else
	{
		var circular=document.getElementById('txtcircularno').value;
		var status=document.getElementById('drpstatus').value;
		var compcode = document.getElementById('hiddencompcode').value;
		var userid = document.getElementById('hiddenuserid').value;
		var retcode = document.getElementById('hiddenretcode').value;
		var dateformat = document.getElementById('hiddendateformat').value;
		var fromdate=document.getElementById('txtfrom').value;
	var todate=document.getElementById('txtto').value;
	
	if(dateformat=="mm/dd/yyyy")
	{
	var txtfrom=document.getElementById('txtfrom').value;
	var txtto=document.getElementById('txtto').value;
	}
		
		if(dateformat=="dd/mm/yyyy")
		{
			var txtstatusfrom=fromdate.split("/");
			var ddfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var yyfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var ddtill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var yytill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		if(dateformat=="yyyy/mm/dd")
		{
			var txtstatusfrom=fromdate.split("/");
			var yyfrom=txtstatusfrom[0];
			var mmfrom=txtstatusfrom[1];
			var ddfrom=txtstatusfrom[2];
			txtfrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
			
			var txtstatustill=todate.split("/");
			var yytill=txtstatustill[0];
			var mmtill=txtstatustill[1];
			var ddtill=txtstatustill[2];
			txtto=mmtill+'/'+ddtill+'/'+yytill;
		}
		
		
			//Update the Records
			RetainerStatusMaster.Ret_StatusOperation(userid,compcode,retcode,status,txtfrom,txtto,circular,codestatusid,1);
			window.location=window.location;
			return false;
		
	}
	window.location=window.location;
	return false;


}

//Status select value from Datagrid
function CommissionSelect(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtefffrom').value="";
       document.getElementById('txtefftill').value="";
       document.getElementById('drpcommdetail').value="0";
       document.getElementById('txtcommrate').value="";
       document.getElementById('txtframt').value="";
       document.getElementById('txttoamt').value="";
       document.getElementById('txtaddcommrate').value="";
       if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSubmit').disabled=true;
       }
//       else
//       {
//            document.getElementById('btnSubmit').disabled=false;
//       }
       document.getElementById('btndelete').disabled=true;
       document.getElementById(ab).checked=false;
       return;// false;
        
    }
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	
	    document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;
// saurabh change    
    if(document.getElementById('hiddendelsau').value=="1")
	{
   document.getElementById('btndelete').disabled= false;
    }

    if(id==str)
        {
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	code11=document.getElementById(str).value;
	chkclick=document.getElementById(id);
	
	//saurabh change
	
	if(document.getElementById('hiddendelsau').value=="1")
	{
	document.getElementById('btndelete').disabled= false;
    }
	
	}
	}
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}
//	else
//	{
//		document.getElementById('btndelete').disabled=false;
//	
//	}
	RetainerCommDetails.bandcomm(retcode,compcode,userid,code11,dateformat,SelectComm_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
        document.getElementById('txtefffrom').value="";
       document.getElementById('txtefftill').value="";
       document.getElementById('drpcommdetail').value="0";
       document.getElementById('txtcommrate').value="";
          
	return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnSubmit').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	
}



//function callback to fill the values to the controls
function SelectComm_CallBack(response)
{
	var ds = response.value;
//	if(ds.Tables[0].Rows.length>0)
//	{
//		var dateformat = document.getElementById('hiddendateformat').value;
//		
//		var fromdate1 = ds.Tables[0].Rows[0].From_date;
//		var todate1 = ds.Tables[0].Rows[0].to_date;
//		var ddfrom = fromdate1.getDate();
//		var mmfrom = fromdate1.getMonth()+ 1;
//		var yyyyfrom = fromdate1.getFullYear();
//		var ddtill = todate1.getDate();
//		var mmtill = todate1.getMonth() + 1;
//		var yyyytill = todate1.getFullYear();
//		
//		if(dateformat=="dd/mm/yyyy")
//		{
//			txtfrom=ddfrom+'/'+mmfrom +'/'+yyyyfrom ;
//			txtto=ddtill+'/'+mmtill+'/'+yyyytill;
//			
//		}
//		else if(dateformat=="yyyy/mm/dd")
//		{
//			txtfrom=yyyyfrom +'/'+mmfrom +'/'+ddfrom ;
//			txtto=yyyytill+'/'+mmtill+'/'+ddtill;
//		}
//		else
//		{
//			txtfrom=mmfrom +'/'+ddfrom +'/'+yyyyfrom ;
//			txtto=mmtill+'/'+ddtill+'/'+yyyytill;
//		}
				
		updatecommission = ds.Tables[0].Rows[0].comm_code;
		
		document.getElementById('txtefffrom').value=ds.Tables[0].Rows[0].Eff_from_date;
		document.getElementById('txtefftill').value=ds.Tables[0].Rows[0].Eff_Till_date;
		document.getElementById('drpcommdetail').value = ds.Tables[0].Rows[0].discount;
		document.getElementById('txtcommrate').value = ds.Tables[0].Rows[0].comm_rate;
		if( ds.Tables[0].Rows[0].FROMAMOUNT!=null)
           document.getElementById('txtframt').value = ds.Tables[0].Rows[0].FROMAMOUNT;
        else
           document.getElementById('txtframt').value ="";
        if(ds.Tables[0].Rows[0].TOAMOUNT!=null)
		    document.getElementById('txttoamt').value = ds.Tables[0].Rows[0].TOAMOUNT;
		else
		    document.getElementById('txttoamt').value ="";
		if(ds.Tables[0].Rows[0].Addl_Comm_Rate!=null)
		{
		    document.getElementById('txtaddcommrate').value = ds.Tables[0].Rows[0].Addl_Comm_Rate;
		}
		else
		{
		  document.getElementById('txtaddcommrate').value ="";
		}
		document.getElementById('hiddenccode').value = ds.Tables[0].Rows[0].comm_code;
		
//	}
//	else
//	{
//		alert("Please Click the Checkbox");
//		return false;
//	}
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSubmit').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnSubmit').disabled=false;
	}
	
	return false;
}


function tddisplay()
{
		var show=document.getElementById('hiddenshow').value;
		var retcode=document.getElementById('hiddenretcode').value; 
		var compcode = document.getElementById('hiddencompcode').value;
	    var userid = document.getElementById('hiddenuserid').value;
		//alert(show);
			if(show==1)
				{
				RetainerPaymode.chk(compcode,userid,retcode,callshow)
				}
				
			else
			{
				//document.getElementById('updat').style.display="block";
//	var chkList234= document.getElementById("rdolistsubmit");
//    var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
//    var sel=document.getElementById("hiddenval").value;
//    for(var j=0;j<arrayOfCheckBoxes.length;j++)
//    {
//        if(arrayOfCheckBoxes[j].value==sel)
//            {
//                arrayOfCheckBoxes[j].checked=true;
//                break;
//            }
//    }
//				document.getElementById('updat1').style.display="block";
//				}
				
				document.getElementById('updat').style.display="block";
				document.getElementById('updat1').style.display="block";
				}
				
return false;
}
function callshow(res)
{
var ds=res.value;

if(ds.Tables[0].Rows.length==0)
//var show=document.getElementById('hiddenshow').value;
{
		document.getElementById('sub').style.display="block";
		document.getElementById('sub1').style.display="block";
}
else
{
		document.getElementById('updat').style.display="block";
		document.getElementById('updat1').style.display="block";
		document.getElementById('btnUpdate').disabled=false;

}		
				
return false;
}

function chk123()
{
		document.getElementById('sub').style.display="none";
		document.getElementById('sub1').style.display="none";
		
		document.getElementById('updat').style.display="block";
		document.getElementById('updat1').style.display="block";

return false;
}





function autoornot()
 {
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
if(hiddentext=="New" )
{
	if(document.getElementById('txtretainername').value!="")
                {
                 document.getElementById('txtretainername').value=trim(document.getElementById('txtretainername').value.toUpperCase());
	            if(saurabh=="1")
	            {
	                document.getElementById('txtalias').value=document.getElementById('txtretainername').value;
	            }
		        str=document.getElementById('txtretainername').value;
		        RetainerMaster.chkretainercode(str,fillcall);
		        return false;
                }
		     //return false;
           
             }
            else
            {
            document.getElementById('txtretainername').value=trim(document.getElementById('txtretainername').value.toUpperCase());
            }
return false;
}


//auto generated
//this is used for increment in code

//function uppercase3()
//		{
////		    if(document.getElementById('txtretainername').value!="")
////                {
////                 document.getElementById('txtretainername').value=trim(document.getElementById('txtretainername').value.toUpperCase());
////	            if(saurabh=="1")
////	            {
////	                document.getElementById('txtalias').value=document.getElementById('txtretainername').value;
////	            }
////		        str=document.getElementById('txtretainername').value;
////		        RetainerMaster.chkretainercode(str,fillcall);
////		        return false;
////                }
////		     return false;
//		
//}

function fillcall(res)
		{
		var ds=res.value;
		if(ds==null)
		{
		alert(res.error.description);
		return false;
		}
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    if(saurabh!="0")
		    {
		    
		    document.getElementById('txtretainername').value="";
		    alert("This Retainer Name has already assigned !! ");
		    
		    if(saurabh=="1")
		    {
		    document.getElementById("txtalias").value="";
		    document.getElementById("txtretainercode").value="";
		    }
		    
		    document.getElementById('txtretainername').focus();
		    
 
    		
		    return false;
		    }
		    }
		
		        else
		        {
		                if(saurabh=="1")
		                {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Retain_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;//.substr(2,4);
		                        code++;
		                        document.getElementById('txtretainercode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtretainercode').value=str.substr(0,2)+ "0";
		                          }
		                   }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="New")
        {
        
        document.getElementById('txtretainercode').disabled=false;
        document.getElementById('txtretainercode').value=document.getElementById('txtretainercode').value.toUpperCase();
        document.getElementById('txtretainername').value=document.getElementById('txtretainername').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtretainername').value;
        auto=document.getElementById('hiddenauto').value;
        
        strname=document.getElementById('txtretainername').value;
        strcode=document.getElementById('txtretainercode').value;

            RetainerMaster.chkretainerusercode(strcode,strname,fcall_cell);
         return false;
        }

//return false;
}
	
function fcall_cell(response)
  {
          var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			    alert("This  Code  Is Already Exist, Try Another Code !!!!"); 
			    document.getElementById('txtretainercode').value="";
			     document.getElementById('txtretainername').value="";
			    document.getElementById('txtretainercode').focus();
			    return false;
			}
		 if(ds.Tables[1].Rows.length > 0)
			{
			  alert("This Retainer Name has already been assigned"); 
			  document.getElementById('txtretainername').value="";
			  document.getElementById('txtretainername').focus();
			  return false;
			}
			return false;
  }


//city bind on select country..

function addcount(cou)
{
if(typeof(cou)=="object")
{
var country=cou.value;
}
else
{
var country=cou;
}
//var country=document.getElementById('txtcountry').value;
if(country!="0")
{
//RetainerMaster.addcout(country,callcount);
//RetainerMaster.getfromc();]
document.getElementById('txtdistrict').value="";
document.getElementById('txtstate').value="";
document.getElementById('drpzone').value="0";
document.getElementById('drpregion').value="0";
document.getElementById('drptaluka').value="0";
var res=RetainerMaster.getfromc(country);
var ds=res.value;
var pkgitem = document.getElementById("drpcity");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select City--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
        
       pkgitem.options.length;
       
    }
    //alert(cityvar);
 
 if(cityvar == undefined || cityvar=="")
 {
  document.getElementById('drpcity').value="0";
 
 }
 else
 {
  document.getElementById('drpcity').value=cityvar;
  cityvar="";
  } 
 
}
else
{
if(document.getElementById('drpcity').disabled==false)
{
alert("There is No Matching value Found");
}
  pkgitem.options.length = 1; 
pkgitem.options[0]=new Option("--Select City--","0");
//return false;

}

}
else
{
document.getElementById("drpcity").options.length = 1;
document.getElementById('txtdistrict').value="";
document.getElementById('txtstate').value="";
document.getElementById('drpzone').value="0";
document.getElementById('drpregion').value="0";
document.getElementById('drptaluka').value="0";
}
return false;
}

function callcount(res)
{

var ds=res.value;
var pkgitem = document.getElementById("drpcity");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select City--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
        
       pkgitem.options.length;
       
    }
    //alert(cityvar);
 
 if(cityvar == undefined || cityvar=="")
 {
  document.getElementById('drpcity').value="0";
 
 }
 else
 {
  document.getElementById('drpcity').value=cityvar;
  cityvar="";
  } 
 
}
else
{
if(document.getElementById('drpcity').disabled==false)
{
alert("There is No Matching value Found");
}
  pkgitem.options.length = 1; 
pkgitem.options[0]=new Option("--Select City--","0");
//return false;

}

return false;
}




//state and district on selection of city name...
    function adddiststate(city)
    {

        if(typeof(city)=="object")
        {
        var city1=city.value;
        }
        else
        {
        var city1=city;
        }
       
        if(city1!="0")		
	    {
	        RetainerMaster.addcitydist(city1, document.getElementById('hiddencompcode').value,FillDropDownList_CallBackMaindoc);
        }
 
        else
        {
           
            document.getElementById('txtdistrict').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('drpzone').value="0";
            document.getElementById('drpregion').value="0";
            document.getElementById('drptaluka').value="0";
        }
					    //document.getElementById('dpstate').focus();	
     return false;

    }





			
function FillDropDownList_CallBackMaindoc(response) 
{
			
	var ds = response.value;
	
	var cou="INDIA";	
	
	var region=document.getElementById('drpregion');
	var zone=document.getElementById('drpzone');
	var taluka=document.getElementById('drptaluka');
	
	if(document.getElementById('drpcity').value!="0" && document.getElementById('drpcity').value!="")
   {
	if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
		{	
                document.getElementById("drpzone").options[0]=new Option("------Select Zone------","0");
				document.getElementById("drpregion").options[0]=new Option("-----Select Region-----","0");
				document.getElementById("drptaluka").options[0]=new Option("------Select Taluka------","0");
				
				document.getElementById("drpregion").options.length=0;		
				document.getElementById("drpregion").options.length=ds.Tables[3].Rows.length;
				
				document.getElementById("drpzone").options.length=0;		
				document.getElementById("drpzone").options.length=ds.Tables[4].Rows.length;
				
				document.getElementById("drptaluka").options.length=0;		
				document.getElementById("drptaluka").options.length=ds.Tables[8].Rows.length;
				
			
    		        if(ds.Tables[3].Rows.length>0)
    		        {	
    				for(var i=0;i<ds.Tables[3].Rows.length;++i) 
	    			{
    					document.getElementById("drpregion").options[i]=new Option(ds.Tables[3].Rows[i].region_name,ds.Tables[3].Rows[i].region_code);
	    			}	
	    			document.getElementById('drpregion').value=ds.Tables[3].Rows[0].region_code;
	    			regioncode=ds.Tables[3].Rows[0].region_code;
	    			
	        	    }
        		    else
                    {
                       if(document.getElementById('drpcity').disabled==false)
                       {
                            //alert("There is no matching value(s) found for region");change due to no region in city master
                       }
                       //document.getElementById('drpregion').disabled=true;
                       region.options.length=0;
                       //return false;

                    }	
				
					
			
					if(ds.Tables[0].Rows.length>0)
					{
					document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					statecode=ds.Tables[0].Rows[0].state_code;
					}
					else
				    {
				    if(document.getElementById('drpcity').disabled==false)
                    {
				        alert("There is no matching value for state");
				    }
				   document.getElementById('txtstate').value="";
				 
				    }
					
				
				
					if(ds.Tables[1].Rows.length>0)
					{
					document.getElementById('txtdistrict').value=ds.Tables[1].Rows[0].dist_name;
					distcode=ds.Tables[1].Rows[0].dist_code;
					}
					else
				    {
				    if(document.getElementById('drpcity').disabled==false)
                    {
				        //alert("There is no matching value for district");//change due to no region in city master
				    }
				    document.getElementById('txtdistrict').value="";
				    		
				    }
					
					if(ds.Tables[8].Rows.length>0)
    		        {	
    				for(var i=0;i<ds.Tables[8].Rows.length;++i) 
	    			{
    					document.getElementById("drptaluka").options[i]=new Option(ds.Tables[8].Rows[i].talu_name,ds.Tables[8].Rows[i].talu_code);
	    			}	
	    			//document.getElementById('drptaluka').value=ds.Tables[8].Rows[0].talu_code;
	    			//talukacode=ds.Tables[8].Rows[0].talu_code;
	    		    //================== ad by rinki ===========================================================================///
	    		    	if(dsforexecute !=null)	
	    			       document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[z].TALUKA ;
	    			    else
	    			       document.getElementById('drptaluka').value=ds.Tables[8].Rows[0].talu_code;
	    			  //--------------------------------------------------------------------------------------------------------//
	    		  /*  if(dsforexecute !=null)
	    		    {
	    			    if(show1=="5")
	    			    document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[0].TALUKA;
    	        	    
	        	         if(show1=="6")
	        	        {
	        	        document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[z].TALUKA;
	        	        }
	        	        if(show1=="7")
	        	        {
	        	        document.getElementById('drptaluka').value=dsforexecute.Tables[0].Rows[y].TALUKA;
	        	        }
	        	    }*/
	        	    }
        		    else
                    {
                       if(document.getElementById('drpcity').disabled==false)
                       {
                            //alert("There is no matching value(s) found for region");change due to no region in city master
                       }
                       //document.getElementById('drpregion').disabled=true;
                       taluka.options.length=0;
                       //return false;

                    }
				     show1="0";
				
					
					if(ds.Tables[5].Rows.length>0)
    		        {	
    				for(var i=0;i<ds.Tables[4].Rows.length;++i) 
	    			{
    					document.getElementById("drpzone").options[i]=new Option(ds.Tables[4].Rows[i].zone_name,ds.Tables[4].Rows[i].zone_code);
	    			}	
	    			document.getElementById('drpzone').value=ds.Tables[5].Rows[0].zone_code;
	    			zonecode=ds.Tables[5].Rows[0].zone_code;
	        	    }
        		    else
                    {
                    if(document.getElementById('drpcity').disabled==false)
                    {
                       //alert("There is no matching value(s) found for Zone");//change due to no region in city master
                    }
                       zone.options.length=0;
                    //   document.getElementById('drpzone').disabled=true;
                       //return false;
                    }
										
					if(document.getElementById('hiddensaurabh').value=="1")
                    {
                        document.getElementById('drpregion').disabled=false;
                        document.getElementById('drpzone').disabled=false;
                    }
					
//				}	
				
			}
					
				
		}	
//		 if(regionvar == undefined || regionvar=="")
//         {
//          //document.getElementById('drpregion').value="0";         
//         }
//         else
//         {
//          document.getElementById('drpregion').value=regionvar;
//          regionvar="";
          //}  
//          if(taluka1 == undefined || taluka1=="")
//         {
//          document.getElementById('drptaluka').value="0";
//         
//         }
//         else
//         {
//          document.getElementById('drptaluka').value=taluka1;
//          taluka1="";
//          }  
		//document.getElementById('txtdistrict').value="";
		return false;			
}
			
			
			
			
			



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



//--------------for leading and trailing spaces....



function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}
//function check()
//{
//    document.getElementById('TextBox1').value=trim(document.getElementById('TextBox1').value);
//    alert(document.getElementById('TextBox1').value);
//    return false;
//}

function PopStatusClear()
{   
 
//chkclick.checked=false;

flag2="0";

document.getElementById('txtfrom').value="";
document.getElementById('txtto').value="";
document.getElementById('drpstatus').value="0";
document.getElementById('txtcircularno').value="";


if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSubmit').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSubmit').disabled==false)))
{

var j;
var k=0;

var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	document.getElementById('btndelete').disabled=true;
	 if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSubmit').disabled=true;
       }
       else
       {
            document.getElementById('btnSubmit').disabled=false;
       }
	//document.getElementById('btnsubmit').disabled=true;
	}
}
//document.getElementById('txtfrom').disabled=false;
//document.getElementById('txtto').disabled=false;
//document.getElementById('drpstatus').disabled=false;
//document.getElementById('txtCircular').disabled=false;
  return false;
}

function popcommclear()
{
    //chkclick.checked=false;

flag2="0";

document.getElementById('txtefffrom').value="";
document.getElementById('txtefftill').value="";
document.getElementById('drpcommdetail').value="0";
document.getElementById('txtcommrate').value="";
document.getElementById('txtaddcommrate').value="";
document.getElementById('txtframt').value="";
document.getElementById('txttoamt').value="";

if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSubmit').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSubmit').disabled==false)))
{

var j;
var k=0;

var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	document.getElementById('btndelete').disabled=true;
	 if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSubmit').disabled=true;
       }
       else
       {
            document.getElementById('btnSubmit').disabled=false;
       }
	//document.getElementById('btnsubmit').disabled=true;
	}
}
//document.getElementById('txtfrom').disabled=false;
//document.getElementById('txtto').disabled=false;
//document.getElementById('drpstatus').disabled=false;
//document.getElementById('txtCircular').disabled=false;
  return false;
}
function tabvalue (id)
{

    if(event.keyCode==13)
    {
        if(document.activeElement.id==document.getElementById('drpcity').id && document.getElementById('txtremarks').disabled==true)
        {
            //if(document.getElementById('btnExecute').disabled==false)
            //{
                document.getElementById('btnExecute').focus();
            //}
             event.keyCode=13;
            
            return event.keyCode;
        }
        else if(document.activeElement.id==id)
        {
            if(document.getElementById('btnSave').disabled==false)
            {
                document.getElementById('btnSave').focus();
            }
            return;

        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
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
    
//Number Only Validator

function ClientisNumberComm()
{
	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13)|| (event.keyCode==46))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
	
}


function fillCenter_client()
{
    var pubcode=document.getElementById('drpPName');
    if(pubcode.value=="0")//Cheching if Publication Name dropdown is blank than blank the Other dropdowns
    {
        var PCName=document.getElementById("drppubcent");
        PCName.options.length=0;
        PCName.options[0]=new Option("--Select Center Name--","0");
        
        var ediName=document.getElementById("drpEdition");
        ediName.options.length=0;
        ediName.options.value="";
        ediName.options[0]=new Option("--Select Edition--","0");
        
        supp=document.getElementById("drpSuppliment");
        supp.options.length=0;
        supp.options.value="";
        supp.options[0]=new Option("--Select Suppliment--","0");
        return false;
    }
    else
    {
        if(modify=="1")
        {
            var ediName=document.getElementById("drpEdition");
            ediName.options.length=0;
            ediName.options[0]=new Option("--Select Edition--","0");
            ediName.value="0";
            
            var ediName=document.getElementById("drpSuppliment");
            ediName.options.length=0;
            ediName.options[0]=new Option("--Select Suppliment--","0");
            ediName.value="0";
            
        }
        var pname1=document.getElementById('drpPName').value;
//   var compcode=document.getElementById('hiddencompcode').value;
//   var userid=document.getElementById('hiddenuserid').value;
   
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
RetainerMaster.fillEdiName(pname1,resFillEdiName);
//      RetainerMaster.fillPCName(resFillPCName);
    }
}

//*******This function takes dataset object as parameter and fill the Publication Center Name dropdown******
//function resFillPCName(response)
//{
//    var ds=response.value;
//    pCName = document.getElementById("drppubcent");
//    pCName.options.length = 1; 
//    pCName.options[0]=new Option("--Select Center Name--","0");
//    
//    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
//    {
//        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
//        {
//            pCName.options[pCName.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Cent_name,ds.Tables[0].Rows[i].Pub_cent_Code);
//            pCName.options.length;
//        }
//    }
//    if(dsforexecute!=undefined && dsforexecute!="" && dsforexecute!=null)
//    {
//        document.getElementById("drppubcent").value=dsforexecute.Tables[0].Rows[z].center_code;
//        fillEdiName_client();
//    }
//}
//**********************************************************************************************************
//calling a addummydaypages.aspx.cs function which returns a dataset and pass to called function resFillEdiName
function fillEdiName_client()
{
    var pubcode=document.getElementById('drpPName');
    var pubcenter=document.getElementById('drppubcent');    
    
    if(pubcenter.value=="0")//Cheching if Publication Name dropdown is blank than blank the Other dropdowns
    {
        var ediName=document.getElementById("drpEdition");
        ediName.options.length=0;
        ediName.options[0]=new Option("--Select Edition--","0");
        
        supp=document.getElementById("drpSuppliment");
        supp.options.length=0;
        supp.options[0]=new Option("--Select Suppliment--","0");
        return false;
    }
    else
    { 
    var chkbox=document.getElementById('drpPName').value;
   var compcode=document.getElementById('hiddencompcode').value;
   var userid=document.getElementById('hiddenuserid').value;
   
//        var pubcodeV=pubcode.value;
//        var pubcenterV=pubcenter.value;
        
    }
}
//**********************************************************************************************************

//*******This function takes dataset object as parameter and fill the Edition Name dropdown*****************
function resFillEdiName(response)
{
    var ds=response.value;
    ediName = document.getElementById("drpEdition");
    ediName.options.length = 1; 
    ediName.options[0]=new Option("--Select Edition--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            ediName.options[ediName.options.length] = new Option(ds.Tables[0].Rows[i].Edition_Alias,ds.Tables[0].Rows[i].Edition_Code);
            ediName.options.length;
        }
    }
    
    if(modify=="1")
    {
        var ediName=document.getElementById("drpEdition");
        document.getElementById("drpSuppliment").value="0";
        //ediName.options.length=0;
        //ediName.options[0]=new Option("--Select Suppliment--","0");
//        dsforexecute=null;
        ediName.value="0";
        
        
    }
    
    if(dsforexecute!=undefined && dsforexecute!="" && dsforexecute!=null)
    {
        document.getElementById("drpEdition").value=dsforexecute.Tables[0].Rows[z].EDITION;
        //fillSuppliment_client();
            var pubcodesupp=document.getElementById('drpPName');
        var pubeditsupp=document.getElementById('drpEdition');
        if(pubeditsupp.value=="0")
        {
            supp=document.getElementById("drpSuppliment");
            supp.options.length=0;
            supp.options[0]=new Option("--Select Suppliment--","0");
            return false;
        }
        else
        {
            //var pubcodesuppV=pubcodesupp.value;
    //        var compcodesupp=document.getElementById('hiddencompcode').value;
    //        var pubeditsuppV=pubeditsupp.value;
    var edition=document.getElementById('drpEdition').value;
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
    var ressup=RetainerMaster.fillsupplement(edition);
    var ds=ressup.value;
        supp = document.getElementById("drpSuppliment");
        supp.options.length = 1; 
        supp.options[0]=new Option("--Select Suppliment--","0");
        
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                supp.options[supp.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
                supp.options.length;
            }
            
        }
        //supp.options[supp.options.length] = new Option("MN","MN");
        
        
        if(dsforexecute!=undefined && dsforexecute!="" && dsforexecute!=null)
        {
            document.getElementById("drpSuppliment").value=dsforexecute.Tables[0].Rows[z].SUB_PUB;
        
        }
        }
    }
}
//**********************************************************************************************************

//**********************************************************************************************************

//calling a addummydaypages.aspx.cs function which returns a dataset and pass to called function resFillfillSuppliment
function fillSuppliment_client()
{
    var pubcodesupp=document.getElementById('drpPName');
    var pubeditsupp=document.getElementById('drpEdition');
    if(pubeditsupp.value=="0")
    {
        supp=document.getElementById("drpSuppliment");
        supp.options.length=0;
        supp.options[0]=new Option("--Select Suppliment--","0");
        return false;
    }
    else
    {
        //var pubcodesuppV=pubcodesupp.value;
//        var compcodesupp=document.getElementById('hiddencompcode').value;
//        var pubeditsuppV=pubeditsupp.value;
var edition=document.getElementById('drpEdition').value;
        //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if(httpRequest.overrideMimeType) {
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
var ressup=RetainerMaster.fillsupplement(edition);
var ds=ressup.value;
    supp = document.getElementById("drpSuppliment");
    supp.options.length = 1; 
    supp.options[0]=new Option("--Select Suppliment--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            supp.options[supp.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
            supp.options.length;
        }
        
    }
    //supp.options[supp.options.length] = new Option("MN","MN");
    
    
    if(dsforexecute!=undefined && dsforexecute!="" && dsforexecute!=null)
    {
        document.getElementById("drpSuppliment").value=dsforexecute.Tables[0].Rows[z].SUB_PUB;
    
    }
    }
}
//**********************************************************************************************************

//*******This function takes dataset object as parameter and fill the Suppliment dropdown*****************
function resFillSuppliment(response)
{
    var ds=response.value;
    supp = document.getElementById("drpSuppliment");
    supp.options.length = 1; 
    supp.options[0]=new Option("--Select Suppliment--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            supp.options[supp.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
            supp.options.length;
        }
        
    }
    //supp.options[supp.options.length] = new Option("MN","MN");
    
    
    if(dsforexecute!=undefined && dsforexecute!="" && dsforexecute!=null)
    {
        document.getElementById("drpSuppliment").value=dsforexecute.Tables[0].Rows[z].SUB_PUB;
    
    }
}
//*********************************************************************************************************



 function settime1()
 {
     var dateformat=document.getElementById('hiddendateformat').value;
     if(document.activeElement.id.indexOf('dan')<0)
     {
        alert(" Please Fill The Date In "+dateformat+" Format");
        daid.focus();
        daid.value="";
        
      }
     //input.focus();
 }
 function checkdate_new(input)
 {
 var dateformat=document.getElementById('hiddendateformat').value;
 if(dateformat=="mm/dd/yyyy")
 
 {
 var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
 
 }
 if(dateformat=="yyyy/mm/dd")
 
 {
var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
}
if(dateformat=="dd/mm/yyyy")
{
var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
}

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}
//alert(document.activeElement.id);
//alert(" Please Fill The Date In "+dateformat+" Format");
//popUpCalendar(document.activeElement,document.activeElement,dateformat);
setTimeout(settime1,15);
daid=input;
//return false;
return;
}
else
{ //Detailed check for valid date ranges
if(dateformat=="yyyy/mm/dd")

{
var yearfield=input.value.split("/")[0]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[2]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[0]
var dayfield=input.value.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
}

//if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield)) 
var abcd= dayobj.getMonth()+1;

var date1=dayobj.getDate();
var year1=dayobj.getFullYear();
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}


 
returnval=true
 


if (returnval==false) 

input.select()
return returnval

}

///////////////////////////////bhanu//////////

function  retcomslab()
{
    if ((trim(document.getElementById('txtretainercode').value)!="")&&(document.getElementById('txtretainercode').value!=null))
    {
        for ( var index = 0; index < 200; index++ ) 
        { 
            var RetStatusCode= document.getElementById('txtretainercode').value;
            //popUpWin = window.open("retainercommslab.aspx?show="+show+"&n_m="+saurabh+"&RetStatusCode="+RetStatusCode,"status","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin = window.open("retainercommsstructure.aspx?show=" + show + "&n_m=" + saurabh + "&RetStatusCode=" + RetStatusCode, "status", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin.focus();
            return false;
        } 
        return false;
    }
    else
    {
        if(document.getElementById('hiddenauto')==1)
        {
            alert("Please enter the Retainer Code");
            document.getElementById('txtretainercode').disabled=false;
            document.getElementById('txtretainercode').value="";
            document.getElementById('txtretainercode').focus();
            return false;
        }
        else
        {
            alert("Please enter the Retainer Name");
            document.getElementById('txtretainername').disabled=false;
            document.getElementById('txtretainername').value="";
            document.getElementById('txtretainername').focus();
            return false;    
        }
    }
}
function retainer_slab() {
    if ((trim(document.getElementById('txtretainercode').value) != "") && (document.getElementById('txtretainercode').value != null)) {
        for (var index = 0; index < 200; index++) {
            var RetStatusCode = document.getElementById('txtretainercode').value;
            //popUpWin = window.open("retainercommslab.aspx?show="+show+"&n_m="+saurabh+"&RetStatusCode="+RetStatusCode,"status","resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin = window.open("retainpoup.aspx?show=" + show + "&n_m=" + saurabh + "&RetStatusCode=" + RetStatusCode, "status", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin.focus();
            return false;
        }
        return false;
    }
    else {
        if (document.getElementById('hiddenauto') == 1) {
            alert("Please enter the Retainer Code");
            document.getElementById('txtretainercode').disabled = false;
            document.getElementById('txtretainercode').value = "";
            document.getElementById('txtretainercode').focus();
            return false;
        }
        else {
            alert("Please enter the Retainer Name");
            document.getElementById('txtretainername').disabled = false;
            document.getElementById('txtretainername').value = "";
            document.getElementById('txtretainername').focus();
            return false;
        }
    }
}

 function RetcomslabSubmit()
 {
    //var common=document.getElementById('drpteam').value;
    var common=document.getElementById('drpcommon').value;
	var fromdays=document.getElementById('txtfrom').value;
	var todays=document.getElementById('txtto').value;
	
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var retcode = document.getElementById('hiddenretcode').value;   
	var codepass=document.getElementById('hiddenenln').value;
	var commrate=trim(document.getElementById('txtcommrate').value);
	var agencytype = trim(document.getElementById('drpagentyp').value);
	
	if(parseFloat(document.getElementById('txtfrom').value)>parseFloat(document.getElementById('txtto').value))
	 {
	   alert("From Days cannot be greater than Till Days.");
	   document.getElementById('txtfrom').value="";
	   document.getElementById('txtto').value="";
	   return false;
	 }


	
	
	/*dc=document.getElementById('lblcircular').innerText;

    if(dc.indexOf('*')>=0)
    {
	    if (trim(document.getElementById('txtcommrate').value)=="")
	    {
		    alert('Plese Enter '+(dc.replace('*',"")));
		    document.getElementById('txtcommrate').focus();
		    return false;
	    }
	}*/
	
     //----------check commmision--------------------//
  /*   if(parseFloat(document.getElementById('txtcommrate').value)>100)
	{
	    alert('Commition rate should be less than 100');
	    document.getElementById('txtcommrate').value="";
	    document.getElementById('txtcommrate').focus();
	    return false;
	}*/
	//--------------------- check double dot ------------------------//
	/* if(parseFloat(document.getElementById('txtcommrate').value)!="")
     {
			    if(commrate.match(/^\d+(\.\d{1,3})?$/i))
			    {
			      //return true;
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById('txtcommrate').value="";
			        return false;
			    }
    }*/
     
     //------------------------------------------------//
	
		// Hidden fields for final save event
		
//	opener.document.getElementById('hidden12s').value=common;
//    opener.document.getElementById('hidden32s').value=fromdays;
 //   opener.document.getElementById('hidden42s').value=todays;
		
		
		
		//*************************************************************************
		//                          Start from here
		//*************************************************************************
	
if(document.getElementById("hiddenshow").value=="2")
{

if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","chkretstatus1.aspx?retcode="+retcode+"&codepass="+codepass+"&fromdays="+fromdays+"&todays="+todays+ "&agency_type=" + agencytype, false);
                        httpRequest.send('');
                        dl = httpRequest.responseText;
                     
                   
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
                                
                            }
                           else 
                            {
                                alert('Session Expired.Please Login Again.');
                                return false;
                            }
                        }
                    }




else

{

var xml = new ActiveXObject("Microsoft.XMLHTTP");
xml.Open( "GET","chkretstatus1.aspx?retcode="+retcode+"&codepass="+codepass+"&fromdays="+fromdays+"&todays="+todays+ "&agency_type=" + agencytype, false );
xml.Send();
 var dl=xml.responseText;
		            
		            
		            }
		            if(dl=="yes")
		            {
		                 alert('Session Expired.Please Login Again.');
                        return false;
		            }
		            
		              if(dl=="Y")
		                {
    		
		                alert("This data is already assigned");
	            	    return false;

	                	}
	                	
	     
	        	    else
	        	    {

//                        if  (opener.document.getElementById('hiddenchk').value=="1")
//                        {
                            if(document.getElementById('hiddenchkst').value=="1")
                           {
                               retainercommslab.checkretslabupdate(retcode,compcode,userid,common,commrate,todays,fromdays,codepass,agencytype);
                               
                               window.location=window.location;
				                return false;
				           }
				         else
				         {
                            codepass="";
                            retainercommslab.insertretslab(compcode,userid,retcode,todays,fromdays,codepass,agencytype, insertret_slabcall);
                            //retainercommslab.setviewstatevalue();
                            
                            return false;
				         }
//                       }
//                        else
//                        {
//	                        return ;
//                        }
                   }

            
      }
		else
			{
retainercommslab.setviewstatevalue();

				return;// false;
			}
}


//===========================new changes  ad for retainer slab =============================================//
//----------------------------------------------------------------------------------------------------------//

function insertret_slabcall(response)
{
    var ds=response.value;
    if (ds=="fail")
    {
	    alert("This data has been already assigned");
	    return false;

    }
    else
    {
      var common=document.getElementById('drpcommon').value;
	  var fromdays=document.getElementById('txtfrom').value;
      var todays=document.getElementById('txtto').value;
	  var compcode=document.getElementById('hiddencompcode').value; 
	  var userid=document.getElementById('hiddenuserid').value;
	  var commrate=document.getElementById('txtcommrate').value;
      var retcode = document.getElementById('hiddenretcode').value;  
      var targetid = document.getElementById('hdntargetid').value;  
       var agency_type = document.getElementById('drpagentyp').value;  
		
	   retainercommslab.insertretslab12(compcode,userid,retcode,fromdays, todays, common, commrate,targetid,agency_type);
       window.location=window.location
     }
    
}


function PopSlabClear()
{   
    flag2="0";
    document.getElementById('txtfrom').value="";
    document.getElementById('txtto').value="";
  document.getElementById('txtcommrate').value="";
document.getElementById('drpcommon').value="0";


if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSave').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSave').disabled==false)))
{

 var j;
 var k=0;
 var i=document.getElementById("DataGrid2").rows.length -1;

    for(j=0;j<i;j++)
	{
	  var str="DataGrid1__ctl_CheckBox1"+j;
	  document.getElementById(str).checked=false;
	  document.getElementById('btndelete').disabled=true;
	  if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSave').disabled=true;
       }
       else
       {
            document.getElementById('btnSave').disabled=false;
       }
	}
}

  return false;
}


function SlabSelect(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpcommon').value="0";
       document.getElementById('txtcommrate').value="";
         document.getElementById('drpagentyp').value="0";
      
        
       
       
       
//       if(opener.document.getElementById('hiddensubmod').value==0)
//       {
//            document.getElementById('btnSave').disabled=true;
//       }

       document.getElementById('btndelete').disabled=true;
       document.getElementById(ab).checked=false;
       return;// false;
        
    }
     document.getElementById('hiddenchkst').value="1";
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	    document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(document.getElementById('hiddendelsau').value=="1")
	    {
          document.getElementById('btndelete').disabled= false;
        }

       if(id==str)
       {
	    if(document.getElementById(id).checked==true)
	    {
	        k=k+1;
	        code11=document.getElementById(str).value;
	        chkclick=document.getElementById(id);
	    
	        if(document.getElementById('hiddendelsau').value=="1")
	        {
	        document.getElementById('btndelete').disabled= false;
            }
	
	   }
	  }
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}

	retainercommslab.bindslab(retcode,compcode,userid,code11,SelectSlab_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
        document.getElementById('txtfrom').value="";
        document.getElementById('txtto').value="";
        document.getElementById('drpstatus').value="0";
        document.getElementById('txtcircularno').value="";
        return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnSave').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	
}



//function callback to fill the values to the controls
function SelectSlab_CallBack(response)
{
	var ds = response.value;

				
		//updatecommission = ds.Tables[0].Rows[0].stat_code;
		
		document.getElementById('txtcommrate').value=ds.Tables[0].Rows[0].COMM_RATE;
		document.getElementById('drpcommon').value=ds.Tables[0].Rows[0].COMM_ON;
		document.getElementById('txtfrom').value = ds.Tables[0].Rows[0].FROM_DAYS;
		document.getElementById('txtto').value = ds.Tables[0].Rows[0].TILL_DAYS;
		document.getElementById('hiddenenln').value = ds.Tables[0].Rows[0].ENLN;
		
		document.getElementById('drpagentyp').value = ds.Tables[0].Rows[0].AGENCY_TYPE
		
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSave').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnSave').disabled=false;
	}
	
	return false;
}

function signuploadclick()
{ if(document.getElementById('lblsign').disabled ==false)
{	
var hdnshow="";
var filename=document.getElementById('txtsign').value;
    if(hiddentext=="Query" || hiddentext=="Execute")
    {
        hdnshow="0";
    }
    else
    {
        hdnshow="1";
    }
 var win=window.open('Execsignattatchment.aspx?filename='+filename+'&hiddenshow='+hdnshow,'','width=350px,height=200px,resizable=1,left=0,top=0,scrollbars=yes','','');
 win.focus();
 }
return false;
}

//Status Slab delete
function RetSlabDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
    var enlncode=document.getElementById('hiddenenln').value; 
 	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;



	   retainercommslab.Ret_StatusDeleteSlab(userid,compcode,retcode,enlncode);
	   document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpcommon').value="0";
       document.getElementById('txtcommrate').value="";
       document.getElementById('hiddenenln').value="";	
		
		
		window.location=window.location;
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

/**************************************days slab & Retainer Add Comm code here*************/

function openpage()
{
    show="1";
     var j;
     var inc =2;
     var flag ="false";
     var popupid="";
     if(document.getElementById("DataGrid2") == null || document.getElementById("DataGrid2") == "null")
     {
        for(j=0;j<(document.getElementById("DataGrid1").rows.length -1);j++)	
	  {  
	    var str1="DataGrid1__ctl_CheckBox1"+j; 
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			    popupid=document.getElementById(str1).value;
			}
            
        }
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
        
         var RetStatusCode = document.getElementById('hiddenretcode').value;
        
         var win = window.open("retainercommslab.aspx?show=" + opener.show + "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
       
        }
     }
     else
     	{		
     for(j=0;j<(document.getElementById("DataGrid2").rows.length -1);j++)	
	  {  
	    var str1="DataGrid12__ctl_CheckBox1"+j;
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			     popupid=document.getElementById(str1).value;
			}
            
        }
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
        
         var RetStatusCode = document.getElementById('hiddenretcode').value;
        
         var win = window.open("retainercommslab.aspx?show=" + opener.show + "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
       
        }
  }
  return false;
}


function openaddcomm()
{
   show="1";
   var j;
   var inc =2;
   var flag ="false";
   var popupid="";
    if(document.getElementById("DataGrid2") == null || document.getElementById("DataGrid2") == "null")
     {
        for(j=0;j<(document.getElementById("DataGrid1").rows.length -1);j++)	
	  {  
	    var str1="DataGrid1__ctl_CheckBox1"+j;  
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			     popupid=document.getElementById(str1).value;
			}
            
        }
         
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
         var RetStatusCode = document.getElementById('hiddenretcode').value;
         var win = window.open("retaineraddtionalcomm.aspx?show=" + opener.show + "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
        
        }
     }
     else
     	{	
    for(j=0;j<(document.getElementById("DataGrid2").rows.length -1);j++)	
	  {  
	    var str1="DataGrid12__ctl_CheckBox1"+j;  
	    if(document.getElementById(str1).checked==true)
			{
			    flag="true";
			     popupid=document.getElementById(str1).value;
			}
            
        }
         
         if(flag=="false")
			{
			  alert('Please select the check box first');
			  return false; 
			}
		else
		{
         var RetStatusCode = document.getElementById('hiddenretcode').value;
         var win = window.open("retaineraddtionalcomm.aspx?show=" + opener.show + "&n_m=" + popupid + "&RetStatusCode=" + RetStatusCode, "bharat", "resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px",'','');
        
        }
    } 
    return false;  
}
function poupclose()
{
  window.close();

}

function subpopaddclear()
{
    document.getElementById('txtmainpub').value="";
    document.getElementById('txtpubper').value="";
    //document.getElementById('libox').value="0";
     for(var t=0;t<document.getElementById('libox').options.length;t++)
    {
         document.getElementById('libox').options[t].selected=false;
    }
    return false;
}


/************ajay/28/11/2011*****************/
function Selectgcol(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       document.getElementById('lstpublication').options.length = 1; 
       document.getElementById('lstpublication').options[0]=new Option("--Select Publication--","0");
       //document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";
    
        for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
        {
             document.getElementById('lstpublication').options[t].selected=false;

        }
       
       
       if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSave').disabled=true;
       }
//       else
//       {
//            document.getElementById('btnSave').disabled=false;
//       }

       document.getElementById('btndelete').disabled=true;
document.getElementById(ab).checked=false;
       return;// false;
        
    }
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	    document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(document.getElementById('hiddendelsau').value=="1")
	    {
          document.getElementById('btndelete').disabled= false;
        }

       if(id==str)
       {
	    if(document.getElementById(id).checked==true)
	    {
	        k=k+1;
	        code11=document.getElementById(str).value;
	        chkclick=document.getElementById(id);
	    
	        if(document.getElementById('hiddendelsau').value=="1")
	        {
	        document.getElementById('btndelete').disabled= false;
            }
	
	   }
	  }
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}

	retainercommsstructure.bindstruct(retcode,compcode,userid,code11,Selectgcol_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
       document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       //document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";
        for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
        {
             document.getElementById('lstpublication').options[t].selected=false;
        }
        return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnSave').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	//return false;
}



//function callback to fill the values to the controls
function Selectgcol_CallBack(response)
{

	var ds = response.value;

				
		//updatecommission = ds.Tables[0].Rows[0].stat_code;
		
		document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].FROM_TGT;
       document.getElementById('txtto').value=ds.Tables[0].Rows[0].TO_TGT;
       document.getElementById('drpteam').value=ds.Tables[0].Rows[0].TEAM_CODE;
       document.getElementById('drpadpub').value=ds.Tables[0].Rows[0].AD_TYPE;//PUBL_CODE;
       
       document.getElementById('drpcusttype').value=ds.Tables[0].Rows[0].CUST_TYPE;
       document.getElementById('drpcat').value=ds.Tables[0].Rows[0].ADCTG_CODE;
       document.getElementById('drppubtype').value=ds.Tables[0].Rows[0].PUB_TYPE;
       document.getElementById('hiddenstructcode').value=ds.Tables[0].Rows[0].COMM_TARGET_ID;
       bindpub();

       //document.getElementById('lstpublication').value=ds.Tables[0].Rows[0].PUBLICATION;
        for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
        {
             document.getElementById('lstpublication').options[t].selected=false;
        }
        if(ds.Tables[0].Rows[0].PUBL_CODE !=null && ds.Tables[0].Rows[0].PUBL_CODE !="")
        {
            var edition=ds.Tables[0].Rows[0].PUBL_CODE;            
            var  len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<document.getElementById('lstpublication').options.length; i++)
                {
                    if(document.getElementById('lstpublication').options[i].value==len[a])
                    {
                         document.getElementById('lstpublication').options[i].selected = true;
                    }
//                    else
//                    {
//                        document.getElementById('lstpublication').options[i].selected = false;
//                    }
                }
            }

        }
		
			
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSave').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnSave').disabled=false;
	}
	
	return false;
}

/*************for grid submit**************/
function grdSubmit()
{
if(parseFloat(document.getElementById('txtfrom').value)>parseFloat(document.getElementById('txtto').value))
//   if(parseFloat(txtfrom)>parseFloat(txtto))
	 {
	   alert("From Target cannot be greater than To Target.");
	   document.getElementById('txtfrom').value="";
	   document.getElementById('txtto').value="";
	   return false;
	 }

    var compcode=document.getElementById('hiddencompcode').value; 
    var userid=document.getElementById('hiddenuserid').value;
    var retcode = document.getElementById('hiddenretcode').value;  
    
     var PTEAM_CODE=document.getElementById('drpteam').value;
    var PADCTG_CODE=document.getElementById('drpcat').value;
    var PFROM_TGT=document.getElementById('txtfrom').value;
    
     var PTO_TGT=document.getElementById('txtto').value;
    var PCUST_TYPE=document.getElementById('drpcusttype').value;
    var PAD_TYPE=document.getElementById('drpadpub').value;
    
    
     var PPUB_TYPE=document.getElementById('drppubtype').value;
   // var PPUBL_CODE=document.getElementById('lstpublication').value;
     var PPUBL_CODE = "";
        for(var li=0;  li< document.getElementById('lstpublication').options.length; li++)
        {

            if (document.getElementById('lstpublication').options[li].selected == true)
            {
                if (document.getElementById('lstpublication').options[li].value != "")
                {
                    if(PPUBL_CODE=="")
                        PPUBL_CODE=document.getElementById('lstpublication').options[li].value;
                    else
                        PPUBL_CODE = PPUBL_CODE + "," + document.getElementById('lstpublication').options[li].value;
                }

            }
        }
    var PCOMM_TARGET_ID=document.getElementById('hiddenstructcode').value;
	 	document.getElementById('hiddenpublicationcode').value=PPUBL_CODE;
//	 	document.getElementById("hiddenflag").value="T";
//	 	document.getElementById("hiddenflag2").value="T";
	 	
if(document.getElementById("hiddenshow").value=="2")
{
//		var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		            xml.Open( "GET","chkretstatus1.aspx?retcode="+retcode+"&codepass="+codepass+"&fromdays="+fromdays+"&todays="+todays, false );
//		             xml.Send();
//		            var dl=xml.responseText;
//		            if(dl=="yes")
//		            {
//		                 alert('Session Expired.Please Login Again.');
//                        return false;
//		            }
//		            
//		              if(dl=="Y")
//		                {
//    		
//		                alert("This data is already assigned");
//	            	    return false;

//	                	}
//	        	    else
//	        	    {

//                        if  (opener.document.getElementById('hiddenchk').value=="1")
//                        {
                            if(flag2=="1")
                           {
                               retainercommsstructure.checkretstructslabupdate(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE, PCOMM_TARGET_ID);
                               //(retcode,compcode,userid,common,commrate,todays,fromdays,codepass);
                               window.location=window.location;
				                return false;
				           }
				         else
				         {
                            codepass="";
                            var rescode=retainercommsstructure.getmaxcodeforslab(compcode, userid);
                            var ds = rescode.value;
		                    var commcod=ds.Tables[0].Rows[0].IDNO;
                            retainercommsstructure.insertretstructslab(compcode, userid, retcode, PTEAM_CODE, PADCTG_CODE, PFROM_TGT, PTO_TGT, PCUST_TYPE, PAD_TYPE, PPUB_TYPE, PPUBL_CODE,commcod);// PCOMM_TARGET_ID);
                            window.location=window.location;
                            return false;
				         }
//                       }
//                        else
//                        {
//	                        return ;
//                        }
//                   }

            
      }
		else
			{
     retainercommsstructure.setviewstatevalue();

			return ;
			}
//document.getElementById("hiddenflag").value="T";
}

//============================================ New Changes for Retainer Additional Comm. slab===========================//
function RetaddcomslabSubmit()
 {
   
  	var lstpub = "";
        for(var li=0;  li< document.getElementById('libox').options.length; li++)
        {

            if (document.getElementById('libox').options[li].selected == true)
            {
                if (document.getElementById('libox').options[li].value != "")
                {
                    if(lstpub=="")
                        lstpub=document.getElementById('libox').options[li].value;
                    else
                        lstpub = lstpub + "," + document.getElementById('libox').options[li].value;
                }

         
            }
            
        }
   if (lstpub=="0")
	{
		alert("Plese Select Publication");
		document.getElementById('libox').focus();
		return false;
	}	
   
   
    if (document.getElementById('txtmainpub').value=="")
	{
		alert("Plese Fill Minimum Publication");
		document.getElementById('txtmainpub').focus();
		return false;
	}
   
        if (document.getElementById('txtpubper').value=="")
	{
		alert("Plese Fill Publication");
		document.getElementById('txtpubper').focus();
		return false;
	}
   
   
   
	var compcode=document.getElementById('hiddencompcode').value; 
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat = document.getElementById('hiddendateformat').value;
	var retcode = document.getElementById('hiddenretcode').value; 
	//var lstpub = document.getElementById('libox').value; 

	
	var minpub= document.getElementById('txtmainpub').value; 
	var publication = document.getElementById('txtpubper').value; 
	var targetid=document.getElementById('hiddensno').value;
	var commid=document.getElementById('hdncommid').value;
//	var codepass=document.getElementById('hiddenenln').value;
//	var commrate=trim(document.getElementById('txtcommrate').value);
	
//	if(parseFloat(document.getElementById('txtfrom').value)>parseFloat(document.getElementById('txtto').value))
//	 {
//	   alert("From Days cannot be greater than Till Days.");
//	   document.getElementById('txtfrom').value="";
//	   document.getElementById('txtto').value="";
//	   return false;
//	 }

if(document.getElementById("hiddenshow").value=="2")
{
//		var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		            xml.Open( "GET","chkretstatus1.aspx?retcode="+retcode+"&codepass="+codepass+"&fromdays="+fromdays+"&todays="+todays, false );
//		             xml.Send();
//		            var dl=xml.responseText;
//		            if(dl=="yes")
//		            {
//		                 alert('Session Expired.Please Login Again.');
//                        return false;
//		            }
//		            
//		              if(dl=="Y")
//		                {
//    		
//		                alert("This data is already assigned");
//	            	    return false;

//	                	}
//	        	    else
//	        	    {

//                        if  (opener.document.getElementById('hiddenchk').value=="1")
//                        {
                            if(document.getElementById('hiddenchkst').value=="1")
                           {
                               retaineraddtionalcomm.checkretaddslabupdate(compcode, userid, retcode, lstpub, minpub, publication,targetid);
                               
                               window.location=window.location;
				                return false;
				           }
				         else
				         {
                            codepass="";
                            retaineraddtionalcomm.insertretaddslab(compcode, userid, retcode, lstpub, minpub, publication,commid);
                            window.location=window.location;
                            return false;
				         }
//                       }
//                        else
//                        {
//	                        return ;
//                        }
//                   }

            
      }
		else
			{
retaineraddtionalcomm.setviewstatevalue();

				return;// false;
			}
}

function RetaddSlabDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
//	var datagrid=document.getElementById('DataGrid1');
    var targetid=document.getElementById('hiddensno').value;
// 	var j;
//	var k=0;
//	var i=document.getElementById("DataGrid1").rows.length -1;



	   retaineraddtionalcomm.Ret_AddDeleteSlab(compcode, userid, retcode,targetid);
	   document.getElementById('txtmainpub').value="";
       document.getElementById('txtpubper').value="";
       document.getElementById('libox').value="0";
  
		window.location=window.location;
		return false;	
}
function AddSlabSelect(ab)
{
    var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('txtmainpub').value="";
       document.getElementById('txtpubper').value="";
       //document.getElementById('libox').value="0";
        document.getElementById('hiddenchkst').value="0";
        document.getElementById('hiddensno').value="";
         for(var t=0;t<document.getElementById('libox').options.length;t++)
        {
             document.getElementById('libox').options[t].selected=false;
        }
       
       if(opener.document.getElementById('hiddensubmod').value==0)
       {
//            document.getElementById('btnsubmit').disabled=true;
       }

       document.getElementById('btndelete').disabled=true;
       document.getElementById(ab).checked=false;
       return;// false;
        
    }
     document.getElementById('hiddenchkst').value="1";
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
	var datagrid=document.getElementById('DataGrid1');
	var dateformat = document.getElementById('hiddendateformat').value;
	
	var j;
	var k=0;
	var i=document.getElementById("DataGrid1").rows.length -1;
	
	for(j=0;j<i;j++)
	{
		var str="DataGrid1__ctl_CheckBox1"+j;
	    document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(document.getElementById('hiddendelsau').value=="1")
	    {
          document.getElementById('btndelete').disabled= false;
        }

       if(id==str)
       {
	    if(document.getElementById(id).checked==true)
	    {
	        k=k+1;
	        code11=document.getElementById(str).value;
	        chkclick=document.getElementById(id);
	    
	        if(document.getElementById('hiddendelsau').value=="1")
	        {
	        document.getElementById('btndelete').disabled= false;
            }
	
	   }
	  }
	}
	if(k==1)
	{
	if((document.getElementById('hiddenshow').value=="1"))
	{
	document.getElementById('btndelete').disabled=false;
	}

	retaineraddtionalcomm.bindAddslab(retcode,compcode,userid,code11,SelectAddSlab_CallBack);
	}
	else if(k==0)
	{
		chkclick.checked=false;
         document.getElementById('txtmainpub').value="";
       document.getElementById('txtpubper').value="";
     // document.getElementById('libox').value="0";
       document.getElementById('hiddensno').value="";
        for(var t=0;t<document.getElementById('libox').options.length;t++)
        {
             document.getElementById('libox').options[t].selected=false;
        }
        return false;
	}
	document.getElementById(ab).checked=true;
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('btnsubmit').disabled==false)
	    {
	        flag2="1";
	    }
	    else
	    {
	        flag2="0";
	    }
	}
	else
	{
	        flag2="0";
	}
	
}

//function callback to fill the values to the controls
function SelectAddSlab_CallBack(response)
{
	var ds = response.value;
		
		document.getElementById('txtmainpub').value=ds.Tables[0].Rows[0].NO_OF_PUBL;
		document.getElementById('txtpubper').value=ds.Tables[0].Rows[0].ADCOMM_PER;
		//document.getElementById('libox').value = ds.Tables[0].Rows[0].PUBL_CODE;
		
		for(var t=0;t<document.getElementById('libox').options.length;t++)
        {
             document.getElementById('libox').options[t].selected=false;
        }
        if(ds.Tables[0].Rows[0].PUBL_CODE !=null && ds.Tables[0].Rows[0].PUBL_CODE !="")
        {
            var edition=ds.Tables[0].Rows[0].PUBL_CODE;            
            var  len=edition.split(",");
            for(var a=0; a<len.length; a++)
            {
                for(var i=1; i<document.getElementById('libox').options.length; i++)
                {
                    if(document.getElementById('libox').options[i].value==len[a])
                    {
                         document.getElementById('libox').options[i].selected = true;
                    }
//                    else
//                    {
//                        document.getElementById('lstpublication').options[i].selected = false;
//                    }
                }
            }

        }
		document.getElementById('hiddensno').value = ds.Tables[0].Rows[0].ADD_COMM_ID;
		
	
	 if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('btnSave').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnsubmit').disabled=false;
	}
	
	return false;
}
// To delete in Retainer Comm Structure
function RetstrSlabDelete()
{
	var compcode = document.getElementById('hiddencompcode').value;
	var userid = document.getElementById('hiddenuserid').value;
	var retcode = document.getElementById('hiddenretcode').value;
    var enlncode=document.getElementById('hiddenstructcode').value; 
 var i=document.getElementById("DataGrid1").rows.length -1;
 if(i<=1)
 {
 alert("There must be at least one record") 
 return false;
 }
	   retainercommsstructure.Ret_StructureDeleteSlab(userid,compcode,retcode,enlncode);
	   
	    document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";	
		
		
		window.location=window.location;
		return false;	
}

function Selectcommstruc(ab)
{
    var id=ab;
    var i=document.getElementById("DataGrid2").rows.length -1;
	if(document.getElementById(id).checked==false)
    {
       document.getElementById(ab).checked=false;
//      // return false;
    }
    else
    {
	    for(j=0;j<i;j++)
	    {
		    var str="DataGrid12__ctl_CheckBox1"+j;
	        document.getElementById(str).checked=false;
            //document.getElementById(id).checked=true;
        }
        document.getElementById(id).checked=true;
    }
   // return false;   
}

function PopadcommstSlabClear()
{   
    flag2="0";
     document.getElementById('txtfrom').value="";
       document.getElementById('txtto').value="";
       document.getElementById('drpteam').value="0";
       document.getElementById('drpadpub').value="0";
       
       document.getElementById('drpcusttype').value="0";
       document.getElementById('drpcat').value="0";
       document.getElementById('drppubtype').value="0";
       document.getElementById('lstpublication').value="";
       document.getElementById('hiddenstructcode').value="";
        document.getElementById('lstpublication').options.length = 1; 
       document.getElementById('lstpublication').options[0]=new Option("--Select Publication--","0");

     for(var t=0;t<document.getElementById('lstpublication').options.length;t++)
    {
         document.getElementById('lstpublication').options[t].selected=false;
    }
    if(document.getElementById("DataGrid1") ==null)
    {
        var i=document.getElementById("DataGrid2").rows.length -1;
        for(j=0;j<i;j++)
        {
            var str="DataGrid12__ctl_CheckBox1"+j;
            document.getElementById(str).checked=false;
        }
    }
    else
    {
        var i=document.getElementById("DataGrid1").rows.length -1;
        for(j=0;j<i;j++)
        {
            var str="DataGrid1__ctl_CheckBox1"+j;
            document.getElementById(str).checked=false;
        }
    }
/*
if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('btnSave').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('btnSave').disabled==false)))
{

 var j;
 var k=0;
 var i=document.getElementById("DataGrid2").rows.length -1;

    for(j=0;j<i;j++)
	{
	  var str="DataGrid1__ctl_CheckBox1"+j;
	  document.getElementById(str).checked=false;
	  document.getElementById('btndelete').disabled=true;
	  if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('btnSave').disabled=true;
       }
       else
       {
            document.getElementById('btnSave').disabled=false;
       }
	}
}
*/
  return false;
}

function bindpub()
{

var compcode = document.getElementById('hiddencompcode').value;

var ptype=  document.getElementById('drppubtype').value;
  var response=retainercommsstructure.bindpublicatin(compcode,ptype,"","","");
var ds=response.value;
    var pkgitem = document.getElementById("lstpublication");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Publication--","0");
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].PUBL_NAME,ds.Tables[0].Rows[i].PUBL_CODE);
        
       pkgitem.options.length;   
    }
return false;
}


      function F2fillretainercr_ret()
{if(flag21=="Y")
{
if(event.keyCode==113)
{
    if(document.activeElement.id=="txtretainername")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hiddencompcode').value;
            var retainer =document.getElementById('txtretainername').value;
            document.getElementById("div4").style.display="block";
            document.getElementById('div4').style.top=208+ "px" ;
            document.getElementById('div4').style.left=389+ "px";
            document.getElementById('lstretainer').focus();
            RetainerMaster.fillF2_Creditretainer(compcode,retainer,bindretainer_callbackb);
      }
 }
}
}
function bindretainer_callbackb(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstretainer");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Retainer Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Retain_Name,ds_AccName.Tables[0].Rows[i].Retain_Code);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstretainer").value="0";
        document.getElementById("div4").value="";
        document.getElementById('lstretainer').focus();
   
        return false;

}
 
 
 function Clickretainer_ret(event)
{
    if(event.keyCode==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstretainer")
        {
        if(document.getElementById('lstretainer').value=="0")
            {
                 alert("Please select Retainer Name");
                 return false;
            }
            
            var page = document.getElementById('lstretainer').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstretainer').length-1;k++)
            {   
                if(document.getElementById('lstretainer').options[k].value==page)
                {
                    var abc=document.getElementById('lstretainer').options[k].innerText;
                    document.getElementById('txtretainername').value = abc;
                    
//                    document.getElementById('hdnretainer').value =page;
//                    document.getElementById('hdnretainername').value =abc;
                    
                    document.getElementById("div4").style.display="none";
                    document.getElementById('txtretainername').focus();
                     return false; 
                    
                }
               
            }
          
        
        }
        
      }
         else if(event.keyCode==27)
         {
         
        document.getElementById("div4").style.display="none";
        document.getElementById('txtretainername').focus();
        return false;
         }
     }


     function F2fillempcode(event) {

         if (event.keyCode == 113) {
             if (document.activeElement.id == "txtemcode") {
               var compcode = document.getElementById('hiddencompcode').value;
                 var empname = document.getElementById('txtemcode').value;
                 document.getElementById("divempcode").style.display = "block";
                 aTag = eval(document.getElementById("txtemcode"))
                 var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 document.getElementById('divempcode').style.top = document.getElementById("txtemcode").offsetTop + toppos + "px";
                 document.getElementById('divempcode').style.left = document.getElementById("txtemcode").offsetLeft + leftpos + "px";
                 document.getElementById('lstempcode').focus();
             
                 //$('txtagency').value="";
//                 var compcode = document.getElementById('hiddencompcode').value;
//                 var empname = document.getElementById('txtemcode').value;
//                 document.getElementById("divempcode").style.display = "block";
//                 document.getElementById('divempcode').style.top = 515 + "px";
//                 document.getElementById('divempcode').style.left = 715 + "px";
//                 document.getElementById('lstempcode').focus();
                 var ds = RetainerMaster.empcodebind(compcode, empname);
                 bindempcode_callbackb(ds);
             }
         }

     }

     function bindempcode_callbackb(res) {
         var ds_AccName = res.value;

         if (ds_AccName != null) {
             var pkgitem = document.getElementById("lstempcode");
             pkgitem.options.length = 0;
             pkgitem.options[0] = new Option("-Select Employe Name-", "0");
             pkgitem.options.length = 1;
             for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
                 pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].NAME + '(' + ds_AccName.Tables[0].Rows[i].EMP_CODE + ')', ds_AccName.Tables[0].Rows[i].EMP_CODE);
                 pkgitem.options.length;
             }
         }
         document.getElementById("lstempcode").value = "0";
         document.getElementById("divempcode").value = "";
         document.getElementById('lstempcode').focus();

         return false;

     }


     function Clickrempcode_ret(event) {
     
         if (event.keyCode == 13 || event.type == "click") {
             if (document.activeElement.id == "lstempcode") {
                 if (document.getElementById('lstempcode').value == "0") {
                     alert("Please select Retainer Name");
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
                         document.getElementById('txtemcode').value = abc;

                         document.getElementById('hdempcode').value = page;
                         //                    document.getElementById('hdnretainername').value =abc;

                         document.getElementById("divempcode").style.display = "none";
                         document.getElementById('txtemcode').focus();
                         return false;

                     }

                 }


             }

         }
         else if (event.keyCode == 27) {

             document.getElementById("divempcode").style.display = "none";
             document.getElementById('txtemcode').focus();
             return false;
         }
     }  
     
     
      function F2fillmaincdp(event) {
var key=event.keyCode?event.keyCode:event.which;
if((key==8 && document.activeElement.id=="txtmaincdp") || (event.ctrlKey==true && key==88 && document.activeElement.id=="txtmaincdp") || (key==46 && document.activeElement.id=="txtmaincdp"))
{
     if(key!=113)
     {
      document.getElementById('txtmaincdp').value="";
       document.getElementById('txtmaincds').value="";
       document.getElementById('hiddenmaincdp').value="";
       document.getElementById('hiddenmaincds').value="";
      
      //ClientDocCode="";
     }
}



         if (event.keyCode == 113) {
             if (document.activeElement.id == "txtmaincdp") {
                 //$('txtagency').value="";
                 var compcode = document.getElementById('hiddencompcode').value;
                
                 
                 var unit=document.getElementById('hdn_cds_unit').value.toUpperCase();
                 var cdp="";
                  var name = document.getElementById('txtmaincdp').value;
                  var userid=document.getElementById('hiddenuserid').value;
                 var extra1="";
                 var extra2="";
                 document.getElementById("divmaincdp").style.display = "block";
                 aTag = eval(document.getElementById("txtmaincdp"))
                 var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 document.getElementById('divmaincdp').style.top = document.getElementById("txtmaincdp").offsetTop + toppos + "px";
                 document.getElementById('divmaincdp').style.left = document.getElementById("txtmaincdp").offsetLeft + leftpos + "px";
                 document.getElementById('lstmaincdp').focus();
                 var ds = RetainerMaster.maincdp(compcode, unit,cdp,name,userid,extra1,extra2);
                 bindmaincdp_callbackb(ds);
             }
         }

     }

     function bindmaincdp_callbackb(res) {
         var ds_AccName = res.value;

         if (ds_AccName != null) {
             var pkgitem = document.getElementById("lstmaincdp");
             pkgitem.options.length = 0;
             pkgitem.options[0] = new Option("-Select A/C Name-", "0");
             pkgitem.options.length = 1;
             for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
                 pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].ACC_NAME + '(' + ds_AccName.Tables[0].Rows[i].CDP + ')'+ '-' + ds_AccName.Tables[0].Rows[i].SUB_LEDGER_FLAG , ds_AccName.Tables[0].Rows[i].CDP);
                 pkgitem.options.length;
             }
         }
         document.getElementById("lstmaincdp").value = "0";
         document.getElementById("divmaincdp").value = "";
         document.getElementById('lstmaincdp').focus();

         return false;

     }


     function Clickrmaincdp_ret(event) {

         if (event.keyCode == 13 || event.type == "click") {
             if (document.activeElement.id == "lstmaincdp") {
                 if (document.getElementById('lstmaincdp').value == "0") {
                     alert("Please select A/C Name");
                     return false;
                 }

                 var page = document.getElementById('lstmaincdp').value;
                 agencycode = page;
                 for (var k = 0; k <= document.getElementById('lstmaincdp').length - 1; k++) {
                     if (document.getElementById('lstmaincdp').options[k].value == page) {
                         if (browser != "Microsoft Internet Explorer") {
                             var abc = document.getElementById('lstmaincdp').options[k].textContent;

                         }
                         else {
                             var abc = document.getElementById('lstmaincdp').options[k].innerText;
                         }
                         
                         var abc1=abc.split('-');
                         
                         document.getElementById('txtmaincdp').value = abc1[0];

                         document.getElementById('hiddenmaincdp').value = page;
                         //                    document.getElementById('hdnretainername').value =abc;

                         document.getElementById("divmaincdp").style.display = "none";
                         
                         if(abc1[1]!="Y")
                         {
                         
                          document.getElementById('txtmaincds').disabled=true;
                          document.getElementById('txtmaincdp').focus();
                         }
                         else
                         {
                         document.getElementById('txtmaincds').disabled=false;	
                        
                          document.getElementById('txtmaincds').focus();
                         
                         }
                         
                        // document.getElementById('txtmaincdp').focus();
                         return false;

                     }

                 }


             }

         }
         else if (event.keyCode == 27) {

             document.getElementById("divmaincdp").style.display = "none";
             document.getElementById('txtmaincdp').focus();
             return false;
         }
         else {
             document.getElementById('hiddenmaincdp').value = "";
             document.getElementById('hiddenmaincds').value = "";
             document.getElementById('txtmaincds').value = "";
             
         }
     }
     
     
     
     
     function F2fillmaincds(event)
{

var key=event.keyCode?event.keyCode:event.which;
if((key==8 && document.activeElement.id=="txtmaincds") || (event.ctrlKey==true && key==88 && document.activeElement.id=="txtmaincds") || (key==46 && document.activeElement.id=="txtmaincds"))
{
     if(key!=113)
     {
      document.getElementById('txtmaincds').value="";
       document.getElementById('hiddenmaincds').value="";
      //ClientDocCode="";
     }
}
if(key==113)
{
    if(document.activeElement.id=="txtmaincds")
    {
        var compcode = document.getElementById('hiddencompcode').value;
        document.getElementById("divmaincds").style.display="block";

          var activeid=document.activeElement.id;
          var listboxid="lstmaincds";
        var objchannel=document.getElementById(listboxid);
        var divid="divmaincds";
      
        aTag = eval(document.getElementById(activeid))
        var btag;
        var leftpos=0;
        var toppos=0;        
        do {
            aTag = eval(aTag.offsetParent);
            leftpos    += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag=eval(aTag)
        } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  
      document.getElementById("divmaincds").style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
        document.getElementById("divmaincds").style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";                            
  
         var extra1="";
         var extra2="";
         var unit=document.getElementById('hdn_cds_unit').value.toUpperCase();
         var cdp=document.getElementById('hiddenmaincdp').value;
         var name=document.getElementById('txtmaincds').value.toUpperCase();
         
        RetainerMaster.fillF2cashback(compcode,unit,cdp,name,extra1,extra2,bindcashback_cds_callback);
    }
}
else
{

}

}

function bindcashback_cds_callback(res)
{
var ds_AccName=res.value;

if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0)
{
var pkgitem = document.getElementById("lstmaincds");
pkgitem.options.length = 0;
pkgitem.options[0]=new Option("-Select Sub Account-","0");
pkgitem.options.length = 1;
    for (var i = 0 ; i < ds_AccName.Tables[0].Rows.length; ++i)
    {
    pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].SUB_ACC_NAME+"--"+ds_AccName.Tables[0].Rows[i].CDS,ds_AccName.Tables[0].Rows[i].CDS);
    pkgitem.options.length;
    }
}
document.getElementById("lstmaincds").value="0";
document.getElementById("divmaincds").value="";
document.getElementById("lstmaincds").focus();

return true;
}

function Clickrmaincds_ret(event)
{ 
var key=event.keyCode?event.keyCode:event.which;   
if(key==13 || event.type=="click")
{
    if(document.activeElement.id=="lstmaincds")
    {
        
        if(document.getElementById('lstmaincds').value=="0")
        {
        alert("Please select Cashback Cds");
        return true;
        }

        var page_new = document.getElementById('lstmaincds').value;
        repcode = page_new;
        
        if(browser!="Microsoft Internet Explorer")
        {
        
            for(var k=0;k<=document.getElementById('lstmaincds').length-1;k++)
            {
               // var abc=document.getElementById('lstcashback').options[k].innerHTML;
                if(document.getElementById('lstmaincds').options[k].value==page_new)
                {
                    var abc=document.getElementById('lstmaincds').options[k].textContent;                      
                    document.getElementById('lstmaincds').value = repcode;                      
                    document.getElementById('hiddenmaincds').value=document.getElementById('lstmaincds').value;                        
//                    document.getElementById('hiddenrepcode').value=document.getElementById('lstcashback').value;
                       var cdsname=abc.split('--');
                    
                    
                    document.getElementById('txtmaincds').value=cdsname[0];                     
//                    document.getElementById('hiddenrepupdate').value="updateRepresentaive";   	                     
                 //  alert("hi")
                    //document.getElementById('txt_credit').focus();    
                    //  alert("hi1")                  
                    document.getElementById("divmaincds").style.display="none";
                    break;
                }
            }
        }
        else
        {
        
            for(var k=0;k<=document.getElementById('lstmaincds').length-1;k++)
            {
                if(document.getElementById('lstmaincds').options[k].value==page_new)
                {
                    var abc=document.getElementById('lstmaincds').options[k].innerText;
                    document.getElementById('lstmaincds').value = repcode;
                    document.getElementById('hiddenmaincds').value = document.getElementById('lstmaincds').value;
//                    document.getElementById('hiddenrepcode').value=document.getElementById('lstcashback').value;
                    
                       var cdsname=abc.split('--');
                    
                    document.getElementById('txtmaincds').value=cdsname[0];
//                    document.getElementById('hiddenrepupdate').value="updateRepresentaive";
                    
//                    var cdsname=abc.split('--');
                    
                    //document.getElementById('txt_credit').focus();
                    document.getElementById("divmaincds").style.display="none";
                    break;
                }
            }
        }
document.getElementById("divmaincds").style.display="none";
return false;
}
} 
else if(key==27)
{
document.getElementById("divmaincds").style.display="none";
document.getElementById('txtmaincds').focus();
return false;
}
}

     
     
     
     
     
     
     
     
     
     
     
     
     
//       function F2fillmaincds(event) {

//         if (event.keyCode == 113) {
//             if (document.activeElement.id == "txtmaincds") {
//                 //$('txtagency').value="";
//                 var compcode = document.getElementById('hiddencompcode').value;
//                 var maincdp = document.getElementById('txtmaincds').value;
//                 document.getElementById("divmaincds").style.display = "block";
//                 aTag = eval(document.getElementById("txtmaincds"))
//                 var btag;
//                 var leftpos = 0;
//                 var toppos = 0;
//                 do {
//                     aTag = eval(aTag.offsetParent);
//                     leftpos += aTag.offsetLeft;
//                     toppos += aTag.offsetTop;
//                     btag = eval(aTag)
//                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
//                 document.getElementById('divmaincds').style.top = document.getElementById("txtmaincds").offsetTop + toppos + "px";
//                 document.getElementById('divmaincds').style.left = document.getElementById("txtmaincds").offsetLeft + leftpos + "px";
//                 document.getElementById('lstmaincds').focus();
//                 var ds = RetainerMaster.maincdp(compcode, maincdp,"");
//                 bindmaincds_callbackb(ds);
//             }
//         }

//     }

//     function bindmaincds_callbackb(res) {
//         var ds_AccName = res.value;

//         if (ds_AccName != null) {
//             var pkgitem = document.getElementById("lstmaincds");
//             pkgitem.options.length = 0;
//             pkgitem.options[0] = new Option("-Select A/C Name-", "0");
//             pkgitem.options.length = 1;
//             for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
//                 pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].ACC_NAME + '(' + ds_AccName.Tables[0].Rows[i].CDP + ')', ds_AccName.Tables[0].Rows[i].CDP);
//                 pkgitem.options.length;
//             }
//         }
//         document.getElementById("lstmaincds").value = "0";
//         document.getElementById("divmaincds").value = "";
//         document.getElementById('lstmaincds').focus();

//         return false;

//     }


//     function Clickrmaincds_ret(event) {

//         if (event.keyCode == 13 || event.type == "click") {
//             if (document.activeElement.id == "lstmaincds") {
//                 if (document.getElementById('lstmaincds').value == "0") {
//                     alert("Please select A/C Name");
//                     return false;
//                 }

//                 var page = document.getElementById('lstmaincds').value;
//                 agencycode = page;
//                 for (var k = 0; k <= document.getElementById('lstmaincds').length - 1; k++) {
//                     if (document.getElementById('lstmaincds').options[k].value == page) {
//                         if (browser != "Microsoft Internet Explorer") {
//                             var abc = document.getElementById('lstmaincds').options[k].textContent;

//                         }
//                         else {
//                             var abc = document.getElementById('lstmaincds').options[k].innerText;
//                         }
//                         document.getElementById('txtmaincds').value = abc;

//                         document.getElementById('hiddenmaincds').value = page;
//                         //                    document.getElementById('hdnretainername').value =abc;

//                         document.getElementById("divmaincds").style.display = "none";
//                         document.getElementById('txtmaincds').focus();
//                         return false;

//                     }

//                 }


//             }

//         }
//         else if (event.keyCode == 27) {

//             document.getElementById("divmaincds").style.display = "none";
//             document.getElementById('txtmaincds').focus();
//             return false;
//         }
//         else {
//             document.getElementById('hiddenmaincds').value = "";
//         }
//     }
     
     
     
 function openattach1() {
         //if (document.getElementById('LinkButton1').disabled == false)
         window.open('RetainerAttachment.aspx?filename=' + document.getElementById('hidattachment').value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
         return false;
     }
     function openattach2() {
        // if (document.getElementById('LinkButton1').disabled == false)
             window.open('RetainerAttachment1.aspx?filename=' + document.getElementById('hidattach2').value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
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

function ClientEmailCheck1(q) {
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
function checkSpace(event) {
    if (event.keyCode == 32) {
        return false;
    }
}

function chkmobile(getid) {
    if (document.getElementById('txtmobile').value != "") {
    var mobileno=document.getElementById('txtmobile').value;
    var spltmob=mobileno.split(',');
    
for(var i=0;i<spltmob.length;i++)
{
        if ((spltmob[i]).length != 10 && spltmob[i]!="") {
            alert("Mobile no. must be 10digits")
            document.getElementById('txtmobile').value = ""
            document.getElementById('txtmobile').focus();
            return false;
        }
        else {
        var arym=spltmob[i];
        if (arym[0] == "0") {
            alert("First digits not be 0");
            document.getElementById('txtmobile').focus();
        }
        }
    }
}}

  function F2fillagcode(event)
{

var key=event.keyCode?event.keyCode:event.which;
if((key==8 && document.activeElement.id=="txtoldcod") || (event.ctrlKey==true && key==88 && document.activeElement.id=="txtoldcod") || (key==46 && document.activeElement.id=="txtoldcod"))
{
     if(key!=113)
     {
      document.getElementById('txtoldcod').value="";
       document.getElementById('hdnagcode').value="";
       document.getElementById('hdncdsubcd').value="";
      //ClientDocCode="";
     }
}
if(key==113)
{
    if(document.activeElement.id=="txtoldcod")
    {
        var compcode = document.getElementById('hiddencompcode').value;
        document.getElementById("divagcode").style.display="block";

          var activeid=document.activeElement.id;
          var listboxid="lstagcode";
        var objchannel=document.getElementById(listboxid);
        var divid="divagcode";
      
        aTag = eval(document.getElementById(activeid))
        var btag;
        var leftpos=0;
        var toppos=0;        
        do {
            aTag = eval(aTag.offsetParent);
            leftpos    += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag=eval(aTag)
        } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  
      document.getElementById("divagcode").style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
        document.getElementById("divagcode").style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";                            
  
         var extra1="";
         var extra2="";
         var extra3="";
         var extra4="";
         var extra5="";
         var unit=document.getElementById('hiddenuserid').value.toUpperCase();
         var cdp=document.getElementById('hiddendateformat').value;
         var name=document.getElementById('txtoldcod').value.toUpperCase();
         
        RetainerMaster.fillF2adcodeback(compcode,name,unit,cdp,extra1,extra2,extra3,extra4,extra5,bindagcode_callback);
    }
}
else
{

}

}

function bindagcode_callback(res)
{
var ds_AccName=res.value;

if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0)
{
var pkgitem = document.getElementById("lstagcode");
pkgitem.options.length = 0;
pkgitem.options[0]=new Option("-Select agency name-","0");
pkgitem.options.length = 1;
    for (var i = 0 ; i < ds_AccName.Tables[0].Rows.length; ++i)
    {
    pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].agency_name+"--"+ds_AccName.Tables[0].Rows[i].code_subcode,ds_AccName.Tables[0].Rows[i].code_subcode);
    pkgitem.options.length;
    }
}
document.getElementById("lstagcode").value="0";
document.getElementById("divagcode").value="";
document.getElementById("lstagcode").focus();

return true;
}


function Clickagcode(event)
{ 
var key=event.keyCode?event.keyCode:event.which;   
if(key==13 || event.type=="click")
{
    if(document.activeElement.id=="lstagcode")
    {
        
        if(document.getElementById('lstagcode').value=="0")
        {
        alert("Please select agency name");
        return true;
        }

        var page_new = document.getElementById('lstagcode').value;
        repcode = page_new;
        
        if(browser!="Microsoft Internet Explorer")
        {
        
            for(var k=0;k<=document.getElementById('lstagcode').length-1;k++)
            {
              
                if(document.getElementById('lstagcode').options[k].value==page_new)
                {
                    var abc=document.getElementById('lstagcode').options[k].textContent;                      
                    document.getElementById('lstagcode').value = repcode;                      
                    document.getElementById('hdncdsubcd').value=document.getElementById('lstagcode').value;                        
                       var cdsname=abc.split('--');
                    
                    
                    document.getElementById('txtoldcod').value=cdsname[0];                     
            
                    document.getElementById("divagcode").style.display="none";
                    break;
                }
            }
        }
        else
        {
        
            for(var k=0;k<=document.getElementById('lstagcode').length-1;k++)
            {
                if(document.getElementById('lstagcode').options[k].value==page_new)
                {
                    var abc=document.getElementById('lstagcode').options[k].innerText;
                    document.getElementById('lstagcode').value = repcode;
                    document.getElementById('hdncdsubcd').value = document.getElementById('lstagcode').value;
                    
                       var cdsname=abc.split('--');
                    
                    document.getElementById('txtoldcod').value=cdsname[0];

                    document.getElementById("divagcode").style.display="none";
                    break;
                }
            }
        }
document.getElementById("divagcode").style.display="none";
return false;
}
} 
else if(key==27)
{
document.getElementById("divagcode").style.display="none";
document.getElementById('txtoldcod').focus();
return false;
}
}

function checkmultilocation(a) {
    var ds = "";
    var returnval = ""
    var split = "";
    var branch=document.getElementById('hdn_cds_unit').value;
    var agcode=document.getElementById('hdnagcode').value;
    if (a != "" || a != "undefined") {
        ds = RetainerMaster.fill_agname(document.getElementById('hiddencompcode').value,branch,agcode, a,"","");
        if (ds.value.Tables[0].Rows.length > 0) {
            return ds.value.Tables[0].Rows[0].AGENCY_NAME
        }
        else {
            var a111 = "";
            return a111;
        }



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
            RetainerMaster.fill_gst(compcode, chargetypecode, bindgstc_callback);
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


function CHKDATE(userdate) {
    var mycondate = ""
    if (userdate == null || userdate == "") {
        mycondate = ""
        userdate = "";
        return mycondate
    }
    var dateformate = $('hiddendateformat').value;
    if ($('hiddendateformat').value == "dd/mm/yyyy") {
        var spmonth = "'" + userdate + "'";
        var pp = spmonth.split(" ");
        var mon = pp[1];
        var myDate = new Date(userdate);
        var date = myDate.getDate();

        if (date == 1 || date == 2 || date == 3 || date == 4 || date == 5 || date == 6 || date == 7 || date == 8 || date == 9)
            date = "0" + date;
        var month = myDate.getMonth() + 1;
        if (month == 1 || month == 2 || month == 3 || month == 4 || month == 5 || month == 6 || month == 7 || month == 8 || month == 9)
            month = "0" + month;
        var year = myDate.getFullYear();
        mycondate = date + "/" + month + "/" + year;
        return mycondate;
    }
    else if ($('hiddendateformat').value == "mm/dd/yyyy") {
        var spmonth = "'" + userdate + "'";
        var pp = spmonth.split(" ");
        var mon = pp[1];
        var myDate = new Date(userdate);
        var date = myDate.getDate();
        var month = myDate.getMonth() + 1;
        var year = myDate.getFullYear();
        mycondate = month + "/" + date + "/" + year;
        return mycondate;
    }
    else if ($('hiddendateformat').value == "yyyy/mm/dd") {
        var spmonth = "'" + userdate + "'";
        var pp = spmonth.split(" ");
        var mon = pp[1];
        var myDate = new Date(userdate);
        var date = myDate.getDate();
        var month = myDate.getMonth() + 1;
        var year = myDate.getFullYear();
        mycondate = year + "/" + month + "/" + date;
        return mycondate;
    }
}
