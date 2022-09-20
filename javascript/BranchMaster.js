

var flag;
var z;
var show="0";
var cityvar;
var dsbranchexecute="";
var gbbranchcode;
var gbbranchname;
var gbalias;
var gbcity;
var gbcountry;
var gbpubcenter;
var hiddentext;
var winid;
var chknamemod;
var res2;
var contper;



/*-----For---Upper Case-------------*/
function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
return ;
}
		
function uppercase1()
{
document.getElementById('txtbranchname').value=document.getElementById('txtbranchname').value.toUpperCase();
return ;
}

function uppercase3()
{
document.getElementById('txtbranchcode').value=document.getElementById('txtbranchcode').value.toUpperCase();
return ;
}

function uppercase4()
{
document.getElementById('txtaddress').value=document.getElementById('txtaddress').value.toUpperCase();
return ;
}

function uppercase5()
{
document.getElementById('txtstreet').value=document.getElementById('txtstreet').value.toUpperCase();
return ;
}
function saurabh_ClientSpecialchar1()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)|| (event.keyCode==45)|| (event.keyCode==46) || (event.keyCode==44)|| (event.keyCode==47))
	{
		return true;
	}
	else
	{
		return false;
	}
}
//***************************************************************************************************************************

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
//brcancle('BranchMaster');
}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
                //alert(response);
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
	
	//*****************************************************************************************************************************

		function citydist()
		{
		document.getElementById('txtstate').value="";
		document.getElementById('txtdist').value="";
		document.getElementById('drpzone').value="";
		document.getElementById('drpregion').value="";
		var city=document.getElementById('drpcity').value;
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
          BranchMaster.citysel(city,addcode1);
		 return false;
   }

		function addcode1(response)
		{
			var ds=response.value;
			
			if(ds.Tables[1].Rows.length>0 || ds.Tables[2].Rows.length>0 || ds.Tables[0].Rows.length>0)
			{
				
				if(ds.Tables[1].Rows.length>0)
				{
				    document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				}
				if(ds.Tables[2].Rows.length != null && ds.Tables[2].Rows.length>0)
                {
                   document.getElementById('txtstate').value=ds.Tables[2].Rows[0].state_name;
                }
                else
                {
                    alert("There is no matching value for state");
                    document.getElementById('txtstate').value="";
                    document.getElementById('txtstate').disabled=true;
                }
				//document.getElementById('txtstate').value=ds.Tables[2].Rows[0].state_name;
				
				//=============================== ad by rinki ========================================////
				  if(ds.Tables[5].Rows.length>0)
    		      {	
    				for(var i=0;i<ds.Tables[5].Rows.length;++i) 
	    			{
    					document.getElementById("drpzone").options[i]=new Option(ds.Tables[5].Rows[i].zone_name,ds.Tables[5].Rows[i].zone_code);
	    			}	
	    			document.getElementById('drpzone').value=ds.Tables[5].Rows[0].zone_code;
	        	  }
//        		  else
//                  {
//                    if(document.getElementById('drpcity').disabled==false)
//                    {
//                       //alert("There is no matching value(s) found for Zone");
//                    }
//                       zone.options.length=0;
//                     document.getElementById('drpzone').disabled=true;
//                       return false;
//                  }
                  
                  
                   if(ds.Tables[6].Rows.length>0)
    		        {	
    				for(var i=0;i<ds.Tables[6].Rows.length;++i) 
	    			{
    					document.getElementById("drpregion").options[i]=new Option(ds.Tables[6].Rows[i].region_name,ds.Tables[6].Rows[i].region_code);
	    			}	
	    			document.getElementById('drpregion').value=ds.Tables[6].Rows[0].region_code;
	        	    }
//        		    else
//                    {
//                        
//                       if(document.getElementById('drpcity').disabled==false)
//                       {
//                            //alert("There is no matching value(s) found for region");
//                       }
//                       //document.getElementById('drpregion').disabled=true;
//                       region.options.length=0;
//                       //return false;

//                    }
			
				
				//==========================================================================================
				//document.getElementById('drpzone').value=ds.Tables[5].Rows[0].zone_name;
				//document.getElementById('drpregion').value=ds.Tables[6].Rows[0].region_name;
				//document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].country_name;
				document.getElementById('txtdist').disabled=true;
				document.getElementById('txtstate').disabled=true;
				document.getElementById('drpzone').disabled=true;
				document.getElementById('drpregion').disabled=true;
			//	document.getElementById('txtcountry').disabled=true;
			}
			return false;
		}
		
		function brnew()
		{
		 var msg=checkSession();
        if(msg==false)
        return false;
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

BranchMaster.blanksession();
			flag="0";
			show="1";
			
			
			
		   document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExit').disabled=false;
			
			chkstatus(FlagStatus);
			document.getElementById('btnSave').disabled = false;	
		    document.getElementById('btnQuery').disabled=true;
	        document.getElementById('btnNew').disabled = true;	
		    document.getElementById('hiddenchk').value="0";
		    
		    if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtbranchcode').disabled=true;
		     
    	          }
		   else
		           {
		           document.getElementById('txtbranchcode').disabled=false;
		        
    	           }
		    
		    document.getElementById('drppubcenter').disabled=false;
		    document.getElementById('drppubcenter').disabled=false;
			document.getElementById('txtbranchname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('txtaddress').disabled=false;
			document.getElementById('txtstreet').disabled=false;
			document.getElementById('drpcity').disabled=false;
			document.getElementById('txtdist').disabled=true;
			document.getElementById('txtstate').disabled=false;
			document.getElementById('txtcountry').disabled=false;
			document.getElementById('txtfax').disabled=false;
			document.getElementById('txtpin').disabled=false;
			document.getElementById('txtphone2').disabled=false;
			document.getElementById('txtphone1').disabled=false;
			document.getElementById('txtintegration').disabled=false;
			
			
			document.getElementById('txtfinphone1').disabled=false;
			document.getElementById('txtfinphone2').disabled=false;
			document.getElementById('txtcollphone1').disabled=false;
			document.getElementById('txtcollphone2').disabled=false;
			document.getElementById('txtcirphone1').disabled=false;
			document.getElementById('txtcirphone2').disabled=false;
			document.getElementById('txtnpphone1').disabled=false;
			document.getElementById('txtnpphone2').disabled=false;
			document.getElementById('txtstphone1').disabled=false;
			document.getElementById('txtstphone2').disabled=false;
			
		    /////////////////////////
			document.getElementById('txtGSTIN').disabled = false;
		document.getElementById('txtpanno').disabled = false;
		document.getElementById('txtholder').disabled = false;
		document.getElementById('txtbankname').disabled = false;
		document.getElementById('txtbankacount').disabled = false;
		document.getElementById('txtbankbranch').disabled = false;
		document.getElementById('txtbankcity').disabled = false;
		document.getElementById('txtifsc').disabled = false;

			/////////////////////////////
			document.getElementById('txtemail').disabled=false;
			document.getElementById('drpzone').disabled=false;
			document.getElementById('drpregion').disabled=false;
			document.getElementById('lbcontdetails').disabled = false;
			document.getElementById('txtboxadd').disabled=false;
			document.getElementById('Textnick').disabled=false;
			  var pkgitem = document.getElementById("drpcity");
            pkgitem.options.length = 1; 
             pkgitem.options[0]=new Option("--Select City--","0");
//               if(document.getElementById('hiddenauto').value==1)
//                    {
//                    document.getElementById('txtbranchname').focus();
//                    }
//                    else
//                    {
//                    document.getElementById('txtbranchcode').focus();
//                    }

	        document.getElementById('drppubcenter').focus();
			hiddentext="new"; 
			
			setButtonImages();
		return false;
		}

function branchdelete()
{
 var msg=checkSession();
        if(msg==false)
        return false;
		var userid= document.getElementById('hiddenuserid').value;
		var compcode= document.getElementById('hiddencompcode').value;
		var branchcode= document.getElementById('txtbranchcode').value;
		var branchname= document.getElementById('txtbranchname').value;
		var alias= document.getElementById('txtalias').value;
		var address= document.getElementById('txtaddress').value;
		var street= document.getElementById('txtstreet').value;
		var city= document.getElementById('drpcity').value;
		var country= document.getElementById('txtcountry').value;
		var fax= document.getElementById('txtfax').value;
		var pin= document.getElementById('txtpin').value;
		var phone1= document.getElementById('txtphone1').value;
		var phone2= document.getElementById('txtphone2').value;
		
		 var finphone1 = document.getElementById('txtfinphone1').value;
        var finphone2 = document.getElementById('txtfinphone2').value;
        var collph1 = document.getElementById('txtcollphone1').value;
        var collph2 = document.getElementById('txtcollphone2').value;
        var cirph1 = document.getElementById('txtcirphone1').value;
        var cirph2 = document.getElementById('txtcirphone2').value;
        var npph1 = document.getElementById('txtnpphone1').value;
        var npph2 = document.getElementById('txtnpphone2').value;
        var stph1 = document.getElementById('txtstphone1').value;
        var stph2 = document.getElementById('txtstphone2').value;
		
		var email= document.getElementById('txtemail').value;
		var dateformat=document.getElementById('hiddenDateFormat').value; 
//		var res5=BranchMaster.chkdel(compcode,branchcode,branchname,alias);
//		if(res5.value.Tables[0].Rows[0].NUM != "0")
//		{
//		alert("Branch is in Used. You can't delete");
//		return false;
//		}
//		
		
		boolReturn = confirm("Are you sure you wish to delete this?");
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
		if(boolReturn==1)
		{
			var ip2=document.getElementById('ip1').value;
		    BranchMaster.delet(compcode,userid,branchcode,ip2);
		    BranchMaster.exebranch(compcode,userid,gbbranchcode,gbbranchname,gbalias,gbcountry,gbcity,gbpubcenter,dateformat,delcall)
	    alert("Data Deleted Successfully");
		}     
		else
		{
			return false;
		}
		setButtonImages();
		return false;
}
	
function delcall(res)
{
	dsbranchexecute= res.value;
	len=dsbranchexecute.Tables[0].Rows.length;
	
	if(dsbranchexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('drppubcenter').value="0";
		document.getElementById('txtbranchcode').value="";
		document.getElementById('txtbranchname').value="";
		document.getElementById('txtalias').value="";
		document.getElementById('txtaddress').value="";
		document.getElementById('txtstreet').value="";
		document.getElementById('drpcity').value="0";
		document.getElementById('txtdist').value="";
		document.getElementById('txtstate').value="";
		document.getElementById('txtcountry').value="0";
		document.getElementById('txtfax').value="";
		document.getElementById('txtpin').value="";
		document.getElementById('txtphone2').value="";
		
		document.getElementById('txtphone1').value="";
		
		document.getElementById('txtfinphone1').value="";
			document.getElementById('txtfinphone2').value="";
			document.getElementById('txtcollphone1').value="";
			document.getElementById('txtcollphone2').value="";
			document.getElementById('txtcirphone1').value="";
			document.getElementById('txtcirphone2').value="";
			document.getElementById('txtnpphone1').value="";
			document.getElementById('txtnpphone2').value="";
			document.getElementById('txtstphone1').value="";
			document.getElementById('txtstphone2').value = "";
			document.getElementById('txtGSTIN').disabled = false;
			document.getElementById('txtpanno').disabled = false;
			document.getElementById('txtholder').disabled = false;
			document.getElementById('txtbankname').disabled = false;
			document.getElementById('txtbankacount').disabled = false;
			document.getElementById('txtbankbranch').disabled = false;
			document.getElementById('txtbankcity').disabled = false;
			document.getElementById('txtifsc').disabled = false;
		
		document.getElementById('txtemail').value="";
		brcancle('BranchMaster');
		return false;
	}
	else if(z>=len || z==-1)
	{
			document.getElementById('txtbranchcode').value=dsbranchexecute.Tables[0].Rows[0].Branch_Code;
			document.getElementById('txtbranchname').value=dsbranchexecute.Tables[0].Rows[0].Branch_Name;
			document.getElementById('txtalias').value=dsbranchexecute.Tables[0].Rows[0].Branch_Alias;
			if(dsbranchexecute.Tables[0].Rows[0].Add1== null)
			{
			document.getElementById('txtaddress').value="";
			}
			else
			{
			document.getElementById('txtaddress').value=dsbranchexecute.Tables[0].Rows[0].Add1;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Street== null)
			{
			document.getElementById('txtstreet').value="";
			}
			else
			{
			document.getElementById('txtstreet').value=dsbranchexecute.Tables[0].Rows[0].Street;
			}
			document.getElementById('drpcity').value=dsbranchexecute.Tables[0].Rows[0].City_Code;
			if(dsbranchexecute.Tables[0].Rows[0].Dist_Code== null)
			{
			document.getElementById('txtdist').value="";
			}
			else
			{
			document.getElementById('txtdist').value=dsbranchexecute.Tables[0].Rows[0].Dist_Code;
			}
			document.getElementById('txtstate').value=dsbranchexecute.Tables[0].Rows[0].State_Code;
			document.getElementById('txtcountry').value=dsbranchexecute.Tables[0].Rows[0].Country_Code;
			if(dsbranchexecute.Tables[0].Rows[0].Fax== null)
			{
			document.getElementById('txtfax').value="";
			}
			else
			{
			document.getElementById('txtfax').value=dsbranchexecute.Tables[0].Rows[0].Fax;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Zip== null)
			{
			document.getElementById('txtpin').value="";
			}
			else
			{
			document.getElementById('txtpin').value=dsbranchexecute.Tables[0].Rows[0].Zip;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Phone2== null)
			{
			document.getElementById('txtphone2').value="";
			}
			else
			{
			document.getElementById('txtphone2').value=dsbranchexecute.Tables[0].Rows[0].Phone2;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Phone1== null)
			{
			document.getElementById('txtphone1').value="";
			}
			else
			{
			document.getElementById('txtphone1').value=dsbranchexecute.Tables[0].Rows[0].Phone1;
			}
			
			///////// add nre column///////////////
			
			if(dsbranchexecute.Tables[0].Rows[0].FIN_PHONE1== null)
			{
			document.getElementById('txtfinphone1').value="";
			}
			else
			{
			document.getElementById('txtfinphone1').value=dsbranchexecute.Tables[0].Rows[0].FIN_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].FIN_PHONE2== null)
			{
			document.getElementById('txtfinphone2').value="";
			}
			else
			{
			document.getElementById('txtfinphone2').value=dsbranchexecute.Tables[0].Rows[0].FIN_PHONE2;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[0].COLL_PHONE1== null)
			{
			document.getElementById('txtcollphone1').value="";
			}
			else
			{
			document.getElementById('txtcollphone1').value=dsbranchexecute.Tables[0].Rows[0].COLL_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].COLL_PHONE2== null)
			{
			document.getElementById('txtcollphone2').value="";
			}
			else
			{
			document.getElementById('txtcollphone2').value=dsbranchexecute.Tables[0].Rows[0].COLL_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].CIR_PHONE1== null)
			{
			document.getElementById('txtcirphone1').value="";
			}
			else
			{
			document.getElementById('txtcirphone1').value=dsbranchexecute.Tables[0].Rows[0].CIR_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].CIR_PHONE2== null)
			{
			document.getElementById('txtcirphone2').value="";
			}
			else
			{
			document.getElementById('txtcirphone2').value=dsbranchexecute.Tables[0].Rows[0].CIR_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].NP_PHONE1== null)
			{
			document.getElementById('txtnpphone1').value="";
			}
			else
			{
			document.getElementById('txtnpphone1').value=dsbranchexecute.Tables[0].Rows[0].NP_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].NP_PHONE2== null)
			{
			document.getElementById('txtnpphone2').value="";
			}
			else
			{
			document.getElementById('txtnpphone2').value=dsbranchexecute.Tables[0].Rows[0].NP_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].ST_PHONE1== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone1').value=dsbranchexecute.Tables[0].Rows[0].ST_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].ST_PHONE2== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone2').value=dsbranchexecute.Tables[0].Rows[0].ST_PHONE2;
			}
			
			
			////////////////end////////////////////////
			
			if(dsbranchexecute.Tables[0].Rows[0].EmailID== null)
			{
			document.getElementById('txtemail').value="";
			}
			else
			{
			document.getElementById('txtemail').value=dsbranchexecute.Tables[0].Rows[0].EmailID;
			}
			document.getElementById('drppubcenter').value=dsbranchexecute.Tables[0].Rows[0].pub_center;
	}
	else
	{
			document.getElementById('txtbranchcode').value=dsbranchexecute.Tables[0].Rows[z].Branch_Code;
			document.getElementById('txtbranchname').value=dsbranchexecute.Tables[0].Rows[z].Branch_Name;
			document.getElementById('txtalias').value=dsbranchexecute.Tables[0].Rows[z].Branch_Alias;
			if(dsbranchexecute.Tables[0].Rows[z].Add1== null)
			{
			document.getElementById('txtaddress').value="";
			}
			else
			{
			document.getElementById('txtaddress').value=dsbranchexecute.Tables[0].Rows[z].Add1;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Street== null)
			{
			document.getElementById('txtstreet').value="";
			}
			else
			{
			document.getElementById('txtstreet').value=dsbranchexecute.Tables[0].Rows[z].Street;
			}
			document.getElementById('drpcity').value=dsbranchexecute.Tables[0].Rows[z].City_Code;
			if(dsbranchexecute.Tables[0].Rows[z].Dist_Code== null)
			{
			document.getElementById('txtdist').value="";
			}
			else
			{
			document.getElementById('txtdist').value=dsbranchexecute.Tables[0].Rows[z].Dist_Code;
			}
			document.getElementById('txtstate').value=dsbranchexecute.Tables[0].Rows[z].State_Code;
			document.getElementById('txtcountry').value=dsbranchexecute.Tables[0].Rows[z].Country_Code;
			if(dsbranchexecute.Tables[0].Rows[z].Fax== null)
			{
			document.getElementById('txtfax').value="";
			}
			else
			{
			document.getElementById('txtfax').value=dsbranchexecute.Tables[0].Rows[z].Fax;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Zip== null)
			{
			document.getElementById('txtpin').value="";
			}
			else
			{
			document.getElementById('txtpin').value=dsbranchexecute.Tables[0].Rows[z].Zip;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Phone2== null)
			{
			document.getElementById('txtphone2').value="";
			}
			else
			{
			document.getElementById('txtphone2').value=dsbranchexecute.Tables[0].Rows[z].Phone2;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Phone1== null)
			{
			document.getElementById('txtphone1').value="";
			}
			else
			{
			document.getElementById('txtphone1').value=dsbranchexecute.Tables[0].Rows[z].Phone1;
			}
			if(dsbranchexecute.Tables[0].Rows[z].EmailID== null)
			{
			document.getElementById('txtemail').value="";
			}
			else
			{
			document.getElementById('txtemail').value=dsbranchexecute.Tables[0].Rows[z].EmailID;
			}
			document.getElementById('drppubcenter').value=dsbranchexecute.Tables[0].Rows[z].pub_center;
	}
	
	return false;
}

		
		
		function brmodify()
		{
			flag="1";
			show="2";
			
			document.getElementById('hiddensubmod').value="1";
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
				document.getElementById('btnExit').disabled=false;*/
				
				
		    chknamemod=document.getElementById('txtbranchname').value;	
		   
			hiddentext="modify"; 
	
			chkstatus(FlagStatus);

			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;
			document.getElementById('btnExecute').disabled=true;
			 document.getElementById('hiddenchk').value="1";
			
			document.getElementById('drppubcenter').disabled=false;
			document.getElementById('txtbranchcode').disabled=true;
//			document.getElementById('txtbranchname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
            document.getElementById('txtbranchname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('txtaddress').disabled=false;
			document.getElementById('txtstreet').disabled=false;
			document.getElementById('drpcity').disabled=false;
			document.getElementById('txtdist').disabled=true;
			document.getElementById('txtstate').disabled=true;
			document.getElementById('txtcountry').disabled=false;
			document.getElementById('txtfax').disabled=false;
			document.getElementById('txtpin').disabled=false;
			document.getElementById('txtphone2').disabled=false;
			document.getElementById('txtphone1').disabled=false;
			
			document.getElementById('txtfinphone1').disabled=false;
			document.getElementById('txtfinphone2').disabled=false;
			document.getElementById('txtcollphone1').disabled=false;
			document.getElementById('txtcollphone2').disabled=false;
			document.getElementById('txtcirphone1').disabled=false;
			document.getElementById('txtcirphone2').disabled=false;
			document.getElementById('txtnpphone1').disabled=false;
			document.getElementById('txtnpphone2').disabled=false;
			document.getElementById('txtstphone1').disabled=false;
			document.getElementById('txtstphone2').disabled = false;
			document.getElementById('txtintegration').disabled = false;
			document.getElementById('txtGSTIN').disabled = false;
			document.getElementById('txtpanno').disabled = false;
			document.getElementById('txtholder').disabled = false;
			document.getElementById('txtbankname').disabled = false;
			document.getElementById('txtbankacount').disabled = false;
			document.getElementById('txtbankbranch').disabled = false;
			document.getElementById('txtbankcity').disabled = false;
			document.getElementById('txtifsc').disabled = false;
			document.getElementById('txtemail').disabled=false;
			document.getElementById('drpzone').disabled=false;
			document.getElementById('drpregion').disabled=false;
			document.getElementById('lbcontdetails').disabled=false;
			document.getElementById('txtboxadd').disabled=false;
             document.getElementById('Textnick').disabled=false;
	setButtonImages();
			document.getElementById('btnSave').focus();
		return false;
		}
		
		
function brsave()
{
 var msg=checkSession();
        if(msg==false)
        return false;
    var bc="";

    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('lbpubcenter').textContent;
    }
    else
    {
        bc=document.getElementById('lbpubcenter').innerText;
    }
    if(bc.indexOf('*')>= 0 )
	{
	    if(document.getElementById('drppubcenter').value=="0")
	    {
	        alert('Please Enter '+(bc.replace('*', "")));
	        document.getElementById('drppubcenter').focus();
	        return false;
	    }
	}
    
    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('BranchCode').textContent;
    }
    else
    {
        bc=document.getElementById('BranchCode').innerText;
    }
    if ((document.getElementById('txtbranchcode').value=="")&& (document.getElementById('hiddenauto').value!=1))
	{
	    alert('Please Enter '+(bc.replace('*', "")));
	    document.getElementById('txtbranchcode').focus();
	    return false;
	}
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('BranchName').textContent;
    }
    else
    {
        bc=document.getElementById('BranchName').innerText;
    }			
	 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtbranchname').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtbranchname').focus();
	            return false;
	        }
	    }
    
    if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('Alias').textContent;
    }
    else
    {
        bc=document.getElementById('Alias').innerText;
    }				
	 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtalias').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtalias').focus();
	            return false;
	        }
	    }
	    
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('Address1').textContent;
    }
    else
    {
        bc=document.getElementById('Address1').innerText; 
    }
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtaddress').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtaddress').focus();
	            return false;
	        }
	    }
	    
	    
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('Country').textContent;
    }
    else
    {
        bc=document.getElementById('Country').innerText; 
    }    
	
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtcountry').value)== "0" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtcountry').focus();
	            return false;
	        }
	    }		
	
	if(browser!="Microsoft Internet Explorer")
    {
        bc=document.getElementById('City').textContent;
    }
    else
    {
       bc=document.getElementById('City').innerText; 
    }
	
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('drpcity').value)== "0" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('drpcity').focus();
	            return false;
	        }
	    }
	if(browser!="Microsoft Internet Explorer")
    {
        bc1=document.getElementById('lblboxadd').textContent;
    }
    else
    {
       bc1=document.getElementById('lblboxadd').innerText; 
    }
	
    if(bc1.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtboxadd').value)== "" )
	        {   
		        alert('Please Enter '+(bc1.replace('*', "")));
	            document.getElementById('txtboxadd').focus();
	            return false;
	        }
	    }
	
		
			    var userid=document.getElementById('hiddenuserid').value;
			    var compcode=document.getElementById('hiddencompcode').value;
			    var branchcode=trim(document.getElementById('txtbranchcode').value);
			    var branchname=trim(document.getElementById('txtbranchname').value);
			    var alias=trim(document.getElementById('txtalias').value);
			    var address=trim(document.getElementById('txtaddress').value);
			    var street=trim(document.getElementById('txtstreet').value);
			    var city=document.getElementById('drpcity').value;
			    var dist=document.getElementById('txtdist').value;
			    var state=document.getElementById('txtstate').value;
			    var country=document.getElementById('txtcountry').value;
			    var fax=document.getElementById('txtfax').value;
			    var pin=document.getElementById('txtpin').value;
			    var phone1=document.getElementById('txtphone1').value;
			    var phone2=document.getElementById('txtphone2').value;
			    
			    var finphone1 = document.getElementById('txtfinphone1').value;
        var finphone2 = document.getElementById('txtfinphone2').value;
        var collph1 = document.getElementById('txtcollphone1').value;
        var collph2 = document.getElementById('txtcollphone2').value;
        var cirph1 = document.getElementById('txtcirphone1').value;
        var cirph2 = document.getElementById('txtcirphone2').value;
        var npph1 = document.getElementById('txtnpphone1').value;
        var npph2 = document.getElementById('txtnpphone2').value;
        var stph1 = document.getElementById('txtstphone1').value;
        var stph2 = document.getElementById('txtstphone2').value;
        var integration = document.getElementById('txtintegration').value;
        var gstin = document.getElementById('txtGSTIN').value;
        var pan = trim(document.getElementById('txtpanno').value);
        var accont_holder = document.getElementById('txtholder').value;
        var bank_name = document.getElementById('txtbankname').value;
        var bank_account = document.getElementById('txtbankacount').value;
        var bank_branchcode = document.getElementById('txtbankbranch').value;
        var bank_citycode = document.getElementById('txtbankcity').value;
        var bank_ifsccode = document.getElementById('txtifsc').value;
        var branchaccont = "";
			    var email=trim(document.getElementById('txtemail').value);
			    var zone=document.getElementById('drpzone').value;
			    var region=document.getElementById('drpregion').value;
			    var pubcenter=document.getElementById('drppubcenter').value;
			    var boxadd=document.getElementById('txtboxadd').value;
			    document.getElementById('hiddenbranch').value=document.getElementById('txtbranchcode').value;
    		    document.getElementById('hiddencity').value=document.getElementById('drpcity').value;
    		    document.getElementById('hiddendist').value=document.getElementById('txtdist').value;
    		    document.getElementById('hiddenstate').value=document.getElementById('txtstate').value;
    		
    		
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
			    if(flag=="0")
			     {
			        var page=document.getElementById('txtbranchcode').value;
		            var chk="save";
		            var dl="";
		            if(browser!="Microsoft Internet Explorer")
                    {
                       
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkbranch.aspx?page="+page+"&chk="+chk, false );
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
		                xml.Open("GET","chkbranch.aspx?page="+page+"&chk="+chk, false );
		                xml.Send();
		                dl=xml.responseText;
		                
		            }
		            if(dl=="yes")
	                {
	                       alert('Session Expired.Please Login Again.');
                            return false;
	                }
		
		            if(dl=="Y")
		            {
		                alert("Branch Code has already been assigned");
		                return false;
    		        
		            }
		        else
		        {
        		        
		                var page=document.getElementById('txtbranchcode').value;
		                var chk="pop";
		                var dl="";
		                if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkbranch.aspx?page="+page+"&chk="+chk, false );
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
		                xml.Open("GET","chkbranch.aspx?page="+page+"&chk="+chk, false );
		                xml.Send();
		                dl=xml.responseText;
    		        }
    		            if(dl=="yes")
                        {
                               alert('Session Expired.Please Login Again.');
                                return false;
                        }
    		        
		                    if(dl=="Y")
		                        {
		                        alert("Please Fill Contact Details");
		                        return false;
                		        
		                        }
		                    else
		                        { 
		                           
        		                    if(browser!="Microsoft Internet Explorer")
                                    {
                                      // alert('rinki');
                                        alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                                    }
                                    else
                                    {
                                       //var res=BranchMaster.chkbranchname(branchname,callsave);
                                        alert(xmlObj.childNodes(0).childNodes(0).text);   // DATA SAVE
                                    }
        	
		                        return;
		                        }
		                }

				
			}
			else
			{
			//------------------------------------------------------------------//
			 if(chknamemod==document.getElementById('txtbranchname').value)
               {
                updatestate();
                 //var res=BranchMaster.chkbranchname(branchname,callsave);
               }
               else
               {
             //var res= BranchMaster.chkbranchname(compcode,userid,branchcode,branchname,alias,address,street,city,dist,state,country,fax,pin,phone1,phone2,email,zone,region,pubcenter,ip2,boxadd,Branchnick,finphone1,finphone2,collph1,collph2,cirph1,cirph2,npph1,npph2,stph1,stph2,integration);
               var res=BranchMaster.chkbranchname(branchname,call_modifyclick);
               // callsave(res);
                return false; 
            }
			//------------------------------------------------------------------//
			
		}
	
	
  function call_modifyclick(response)
{
		       var userid=document.getElementById('hiddenuserid').value;
			    var compcode=document.getElementById('hiddencompcode').value;
			    var branchcode=trim(document.getElementById('txtbranchcode').value);
			    var branchname=trim(document.getElementById('txtbranchname').value);
			    var alias=trim(document.getElementById('txtalias').value);
			    var address=trim(document.getElementById('txtaddress').value);
			    var street=trim(document.getElementById('txtstreet').value);
			    var city=document.getElementById('drpcity').value;
			    var dist=document.getElementById('txtdist').value;
			    var state=document.getElementById('txtstate').value;
			    var country=document.getElementById('txtcountry').value;
			    var fax=document.getElementById('txtfax').value;
			    var pin=document.getElementById('txtpin').value;
			    var phone1=document.getElementById('txtphone1').value;
			    var phone2=document.getElementById('txtphone2').value;
			    
                var finphone1 = document.getElementById('txtfinphone1').value;
                var finphone2 = document.getElementById('txtfinphone2').value;
                var collph1 = document.getElementById('txtcollphone1').value;
                var collph2 = document.getElementById('txtcollphone2').value;
                var cirph1 = document.getElementById('txtcirphone1').value;
                var cirph2 = document.getElementById('txtcirphone2').value;
                var npph1 = document.getElementById('txtnpphone1').value;
                var npph2 = document.getElementById('txtnpphone2').value;
                var stph1 = document.getElementById('txtstphone1').value;
                var stph2 = document.getElementById('txtstphone2').value;
			    
			    var email=trim(document.getElementById('txtemail').value);
			    var zone=document.getElementById('drpzone').value;
			    var region=document.getElementById('drpregion').value;
			    var pubcenter=document.getElementById('drppubcenter').value;
			    var boxadd= document.getElementById('txtboxadd').value;
			    var Branchnick = document.getElementById('Textnick').value;
			    var integration = document.getElementById('txtintegration').value;
			    var gstin = document.getElementById('txtGSTIN').value;
      ////////////////////////
			    var pan = trim(document.getElementById('txtpanno').value);
			    var accont_holder = document.getElementById('txtholder').value;
			    var bank_name = document.getElementById('txtbankname').value;
			    var bank_account = document.getElementById('txtbankacount').value;
			    var bank_branchcode = document.getElementById('txtbankbranch').value;
			    var bank_citycode = document.getElementById('txtbankcity').value;
			    var bank_ifsccode = document.getElementById('txtifsc').value;
			    var branchaccont = "";
      /////////////////////////////
			    
			
			   var ds=response.value;
		       if(chknamemod!=document.getElementById('txtbranchname').value)
			   {
                if(ds.Tables[0].Rows.length >= 1)
                {
                    alert("This Branch Name Already Exists.");
                    document.getElementById('txtbranchname').value="";
                    document.getElementById('txtalias').value="";
                    return false;
                }
                 updatestate();
			}
	}		
   function updatestate()
   {
   var ip2=document.getElementById('ip1').value;
   var boxadd= document.getElementById('txtboxadd').value;
   var Branchnick = document.getElementById('Textnick').value;
   BranchMaster.updatebranch(compcode, userid, branchcode, branchname, alias, address, street, city, dist, state, country, fax, pin, phone1, phone2, email, region, zone, pubcenter, ip2, boxadd, Branchnick, finphone1, finphone2, collph1, collph2, cirph1, cirph2, npph1, npph2, stph1, stph2, integration, gstin, pan, accont_holder, bank_name, bank_account, bank_branchcode, bank_citycode, bank_ifsccode)
   //BranchMaster.updatebranch(compcode, userid, branchcode, branchname, alias, address, street, city, dist, state, country, fax, pin, phone1, phone2, email, region, zone, pubcenter, boxadd, Branchnick, branchaccont, finphone1, finphone2, collph1, collph2, cirph1, cirph2, npph1, npph2, stph1, stph2, integration, gstin, pan, accont_holder, bank_name, bank_account, bank_branchcode, bank_citycode, bank_ifsccode)
			dsbranchexecute.Tables[0].Rows[z].Branch_Code= document.getElementById('txtbranchcode').value;
			dsbranchexecute.Tables[0].Rows[z].Branch_Name= document.getElementById('txtbranchname').value;
			dsbranchexecute.Tables[0].Rows[z].Branch_Alias= document.getElementById('txtalias').value;
			dsbranchexecute.Tables[0].Rows[z].Add1= document.getElementById('txtaddress').value;
			dsbranchexecute.Tables[0].Rows[z].Street= document.getElementById('txtstreet').value;
			dsbranchexecute.Tables[0].Rows[z].City_Code= document.getElementById('drpcity').value;
			dsbranchexecute.Tables[0].Rows[z].Dist_Code= document.getElementById('txtdist').value;
			dsbranchexecute.Tables[0].Rows[z].State_Code= document.getElementById('txtstate').value;
			dsbranchexecute.Tables[0].Rows[z].Country_Code= document.getElementById('txtcountry').value;
			dsbranchexecute.Tables[0].Rows[z].Fax= document.getElementById('txtfax').value;
			dsbranchexecute.Tables[0].Rows[z].Branch_Code= document.getElementById('txtpin').value;
			dsbranchexecute.Tables[0].Rows[z].Phone1= document.getElementById('txtphone1').value;
			dsbranchexecute.Tables[0].Rows[z].Phone2= document.getElementById('txtphone2').value;
			dsbranchexecute.Tables[0].Rows[z].EmailID= document.getElementById('txtemail').value;
			dsbranchexecute.Tables[0].Rows[z].Zone_code= document.getElementById('drpzone').value;
			dsbranchexecute.Tables[0].Rows[z].Region_code= document.getElementById('drpregion').value;
	        dsbranchexecute.Tables[0].Rows[z].pub_center= document.getElementById('drppubcenter').value;
	        dsbranchexecute.Tables[0].Rows[z].BOX_ADDRESS= document.getElementById('txtboxadd').value;
	        dsbranchexecute.Tables[0].Rows[z].Branch_nick= document.getElementById('Textnick').value;
	     		    
			    
	        dsbranchexecute.Tables[0].Rows[z].FIN_PHONE1= document.getElementById('txtfinphone1').value;
	        dsbranchexecute.Tables[0].Rows[z].FIN_PHONE2= document.getElementById('txtfinphone2').value;
	        dsbranchexecute.Tables[0].Rows[z].COLL_PHONE1= document.getElementById('txtcollphone1').value;
	        dsbranchexecute.Tables[0].Rows[z].COLL_PHONE2= document.getElementById('txtcollphone2').value;
	        dsbranchexecute.Tables[0].Rows[z].CIR_PHONE1= document.getElementById('txtcirphone1').value;
	        dsbranchexecute.Tables[0].Rows[z].CIR_PHONE2= document.getElementById('txtcirphone2').value;
	        dsbranchexecute.Tables[0].Rows[z].NP_PHONE1= document.getElementById('txtnpphone1').value;
	        dsbranchexecute.Tables[0].Rows[z].NP_PHONE2= document.getElementById('txtnpphone2').value;
	        dsbranchexecute.Tables[0].Rows[z].ST_PHONE1= document.getElementById('txtstphone1').value;
	        dsbranchexecute.Tables[0].Rows[z].ST_PHONE2= document.getElementById('txtstphone2').value;
	        
	        
	        
			updateStatus();
            document.getElementById('drppubcenter').disabled=true;
            					
			document.getElementById('txtbranchcode').disabled=true;
			document.getElementById('txtbranchname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtaddress').disabled=true;
			document.getElementById('txtstreet').disabled=true;
			document.getElementById('drpcity').disabled=true;
			document.getElementById('txtdist').disabled=true;
			document.getElementById('txtstate').disabled=true;
			document.getElementById('txtcountry').disabled=true;
			document.getElementById('txtfax').disabled=true;
			document.getElementById('txtpin').disabled=true;
			document.getElementById('txtphone2').disabled=true;
			document.getElementById('txtphone1').disabled=true;
			
			document.getElementById('txtfinphone1').disabled=true;
			document.getElementById('txtfinphone2').disabled=true;
			document.getElementById('txtcollphone1').disabled=true;
			document.getElementById('txtcollphone2').disabled=true;
			document.getElementById('txtcirphone1').disabled=true;
			document.getElementById('txtcirphone2').disabled=true;
			document.getElementById('txtnpphone1').disabled=true;
			document.getElementById('txtnpphone2').disabled=true;
			document.getElementById('txtstphone1').disabled=true;
			document.getElementById('txtstphone2').disabled=true;
			
			document.getElementById('txtemail').disabled=true;
			document.getElementById('txtboxadd').disabled=true;
			
			document.getElementById('drpzone').disabled=true;
			document.getElementById('drpregion').disabled=true;
			document.getElementById('Textnick').disabled=true;
			if(z==0)
			{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;			
				}
			if(z==dsbranchexecute.Tables[0].Rows.length-1)
			{
				document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnlast').disabled=true;
		
			}
	show="0";
			
			if(browser!="Microsoft Internet Explorer")
            {
                alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
            }
            else
            {
                alert(xmlObj.childNodes(0).childNodes(1).text);
            }
            setButtonImages();
        	return false;
			}
			setButtonImages();
		return false;
   }


function callsave(res)
{
			ds=res.value;
			if(document.getElementById('txtbranchcode').value=="")
			{
			    alert("Please Enter Branch Code");
			    if(document.getElementById('txtbranchcode').disabled==false)
				{
				    document.getElementById('txtbranchcode').focus();
				}
			    return false;
			}
			if(ds.Tables[0].Rows.length>0)
			{
			    alert("This Branch Code Already Exist");
				document.getElementById('txtbranchcode').value="";
				if(document.getElementById('txtbranchcode').disabled==false)
				{
				    document.getElementById('txtbranchcode').focus();
				    return false;
				}
				return false;
		
			}
			else if(ds.Tables[1].Rows.length>0)
			{
			alert("This Branch Name Already Exist");
			return false;
			}
////			else if(ds.Tables[2].Rows.length>0)
////			{
////			alert("This Alias Already Exist");
////			return false;
////			}
////			else
			{
    bc=document.getElementById('BranchCode').innerText;
    if ((document.getElementById('txtbranchcode').value=="")&& (document.getElementById('hiddenauto').value!=1))
    {
        alert('Please Enter '+(bc.replace('*', "")));
        document.getElementById('txtbranchcode').focus();
        return false;
    }
				
				    bc=document.getElementById('BranchName').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtbranchname').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtbranchname').focus();
	            return false;
	        }
	    }
				
				   bc=document.getElementById('Alias').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtalias').value)== "" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtalias').focus();
	            return false;
	        }
	    }
						   bc=document.getElementById('Country').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtcountry').value)== "0" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('txtcountry').focus();
	            return false;
	        }
	    }		
	    
	    			   bc=document.getElementById('City').innerText; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('drpcity').value)== "0" )
	        {   
		        alert('Please Enter '+(bc.replace('*', "")));
	            document.getElementById('drpcity').focus();
	            return false;
	        }
	    }
					var userid= document.getElementById('hiddenuserid').value;
					var compcode= document.getElementById('hiddencompcode').value;
					 var branchcode=trim(document.getElementById('txtbranchcode').value);
			        var branchname=trim(document.getElementById('txtbranchname').value);
			        var alias=trim(document.getElementById('txtalias').value);
			        var address=trim(document.getElementById('txtaddress').value);
			        var street=trim(document.getElementById('txtstreet').value);
					var city= document.getElementById('drpcity').value;
					var dist= document.getElementById('txtdist').value;
					var state= document.getElementById('txtstate').value;
					var country= document.getElementById('txtcountry').value;
					var fax= document.getElementById('txtfax').value;
					var pin= document.getElementById('txtpin').value;
					var phone1= document.getElementById('txtphone1').value;
					var phone2= document.getElementById('txtphone2').value;
					
					var finphone1 = document.getElementById('txtfinphone1').value;
                var finphone2 = document.getElementById('txtfinphone2').value;
                var collph1 = document.getElementById('txtcollphone1').value;
                var collph2 = document.getElementById('txtcollphone2').value;
                var cirph1 = document.getElementById('txtcirphone1').value;
                var cirph2 = document.getElementById('txtcirphone2').value;
                var npph1 = document.getElementById('txtnpphone1').value;
                var npph2 = document.getElementById('txtnpphone2').value;
                var stph1 = document.getElementById('txtstphone1').value;
                var stph2 = document.getElementById('txtstphone2').value;
					
					var email= trim(document.getElementById('txtemail').value);
					var zone= document.getElementById('drpzone').value;
			        var region= document.getElementById('drpregion').value;
			        var boxadd = document.getElementById('txtboxadd').value;
			       var Branchnick = document.getElementById('Textnick').value;
			       var integration = document.getElementById('txtintegration').value;

			    ////////////////////////
			       var pan = trim(document.getElementById('txtpanno').value);
			       var accont_holder = document.getElementById('txtholder').value;
			       var bank_name = document.getElementById('txtbankname').value;
			       var bank_account = document.getElementById('txtbankacount').value;
			       var bank_branchcode = document.getElementById('txtbankbranch').value;
			       var bank_citycode = document.getElementById('txtbankcity').value;
			       var bank_ifsccode = document.getElementById('txtifsc').value;

                /////////////////////////////

			        var branchaccont = "";

			    //BranchMaster.insertbranch(compcode, userid, branchcode, branchname, alias, address, street, city, dist, state, country, fax, pin, phone1, phone2, email, zone, region, boxadd, Branchnick, branchaccont,finphone1, finphone2, collph1, collph2, cirph1, cirph2, npph1, npph2, stph1, stph2, integration)bank_branchcode  varchar2,
			       
			        BranchMaster.insertbranch(compcode, userid, branchcode, branchname, alias, address, street, city, dist, state, country, fax, pin, phone1, phone2, email, region, zone, boxadd, Branchnick, branchaccont,finphone1, finphone2, collph1, collph2, cirph1, cirph2, npph1, npph2, stph1, stph2, integration, pan, accont_holder, bank_name, bank_account, bank_branchcode, bank_citycode, bank_ifsccode)

			
			alert("Data Saved Successfully");
			show="0";
			document.getElementById('drppubcenter').disabled=true;
			
			document.getElementById('txtbranchcode').disabled=true;
			document.getElementById('txtbranchname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtaddress').disabled=true;
			document.getElementById('txtstreet').disabled=true;
			document.getElementById('drpcity').disabled=true;
			document.getElementById('txtdist').disabled=true;
			document.getElementById('txtstate').disabled=true;
			document.getElementById('txtcountry').disabled=true;
			document.getElementById('txtfax').disabled=true;
			document.getElementById('txtpin').disabled=true;
			document.getElementById('txtphone2').disabled=true;
			document.getElementById('txtphone1').disabled=true;
			
			document.getElementById('txtfinphone1').disabled=true;
			document.getElementById('txtfinphone2').disabled=true;
			document.getElementById('txtcollphone1').disabled=true;
			document.getElementById('txtcollphone2').disabled=true;
			document.getElementById('txtcirphone1').disabled=true;
			document.getElementById('txtcirphone2').disabled=true;
			document.getElementById('txtnpphone1').disabled=true;
			document.getElementById('txtnpphone2').disabled=true;
			document.getElementById('txtstphone1').disabled=true;
			document.getElementById('txtstphone2').disabled=true;
			
			document.getElementById('txtemail').disabled=true;
			document.getElementById('drpzone').disabled=true;
			document.getElementById('drpregion').disabled=true;
			document.getElementById('Textnick').disabled = true;
			document.getElementById('txtintegration').disabled = true;
	

			document.getElementById('txtGSTIN').disabled = true;
			document.getElementById('txtpanno').disabled = true;
			document.getElementById('txtholder').disabled = true;
			document.getElementById('txtbankname').disabled = true;
			document.getElementById('txtbankacount').disabled = true;
			document.getElementById('txtbankbranch').disabled = true;
			document.getElementById('txtbankcity').disabled = true;
			document.getElementById('txtifsc').disabled = true;
			
			document.getElementById('drppubcenter').value="0";
			document.getElementById('txtbranchcode').value="";
			document.getElementById('txtbranchname').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('txtaddress').value="";
			document.getElementById('txtstreet').value="";
			document.getElementById('drpcity').value="0";
			document.getElementById('txtdist').value="";
			document.getElementById('txtstate').value="";
			document.getElementById('txtcountry').value="0";
			document.getElementById('txtfax').value="";
			document.getElementById('txtpin').value="";
			document.getElementById('txtphone2').value="";
			document.getElementById('txtphone1').value="";
			document.getElementById('txtemail').value="";
			document.getElementById('drpzone').value="0";
			document.getElementById('drpregion').value="0";
			document.getElementById('Textnick').value = "";
			document.getElementById('txtintegration').value = "";
	
			
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
			
			//cancelclick('UOM');
			brcancle('BranchMaster');
			
			//alert("Data Saved");
			return false;
			}
		
		return false;
		}
		
		function brquery()
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

            BranchMaster.blanksession();
		    document.getElementById('hiddensubmod').value="0";
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExit').disabled=false;*/
			z=0;
			show="0";
			chkstatus(FlagStatus);
			hiddentext="query";
	
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;		
		    document.getElementById('btnExecute').focus();
		    
		    document.getElementById('drppubcenter').disabled=false;
			document.getElementById('txtbranchcode').disabled=false;
			document.getElementById('txtbranchname').disabled=false;
			document.getElementById('txtalias').disabled=false;
//			document.getElementById('txtaddress').disabled=false;
//			document.getElementById('txtstreet').disabled=false;
     		document.getElementById('drpcity').disabled=false;
//			document.getElementById('txtdist').disabled=false;
//			document.getElementById('txtstate').disabled=false;
        	document.getElementById('txtcountry').disabled=false;
//			document.getElementById('txtfax').disabled=false;
//			document.getElementById('txtpin').disabled=false;
//			document.getElementById('txtphone2').disabled=false;
//			document.getElementById('txtphone1').disabled=false;
//			document.getElementById('txtemail').disabled=false;
//			document.getElementById('drpzone').disabled=false;
//			document.getElementById('drpregion').disabled=false;
            document.getElementById('lbcontdetails').disabled =true;
		    
		    document.getElementById('drppubcenter').value="0";
			document.getElementById('txtbranchcode').value="";
			document.getElementById('txtbranchname').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('txtaddress').value="";
			document.getElementById('txtstreet').value="";
			//document.getElementById('drpcity').value="0";
			document.getElementById('txtdist').value="";
			document.getElementById('txtstate').value="";
			document.getElementById('txtcountry').value="0";
			var pkgitem = document.getElementById("drpcity");
            pkgitem.options.length = 1; 
             pkgitem.options[0]=new Option("--Select City--","0");
             
 
			document.getElementById('txtfax').value="";
			document.getElementById('txtpin').value="";
			document.getElementById('txtphone2').value="";
			document.getElementById('txtphone1').value="";
			
			document.getElementById('txtfinphone1').value="";
			document.getElementById('txtfinphone2').value="";
			document.getElementById('txtcollphone1').value="";
			document.getElementById('txtcollphone2').value="";
			document.getElementById('txtcirphone1').value="";
			document.getElementById('txtcirphone2').value="";
			document.getElementById('txtnpphone1').value="";
			document.getElementById('txtnpphone2').value="";
			document.getElementById('txtstphone1').value="";
			document.getElementById('txtstphone2').value="";
			
			document.getElementById('txtemail').value="";
			document.getElementById('drpzone').value="0";
			document.getElementById('drpregion').value="0";
			
			var page=document.getElementById('txtbranchcode').value;
		        var chk="query";
		 if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","chkbranch.aspx?page="+page+"&chk="+chk, false );
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
                    val_=httpRequest.responseText;
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
		        xml.Open( "GET","chkbranch.aspx?page="+page+"&chk="+chk, false );
		        xml.Send();
    	}
		setButtonImages();
		return false;
		}
		
		function brexe()
		{
		 var msg=checkSession();
        if(msg==false)
        return false;
		    document.getElementById('hiddensubmod').value="0";
			var userid= document.getElementById('hiddenuserid').value.toUpperCase();
			var compcode= document.getElementById('hiddencompcode').value.toUpperCase();
			var branchcode= document.getElementById('txtbranchcode').value.toUpperCase();
			gbbranchcode=branchcode;
			var branchname= document.getElementById('txtbranchname').value.toUpperCase();
			gbbranchname=branchname;
			
		    var alias= document.getElementById('txtalias').value.toUpperCase();
			gbalias=alias;
		   
			if(document.getElementById('drpcity').value=="0")
		    {
		    var city= "";
			gbcity=city;
		    }
		    else{
			var city= document.getElementById('drpcity').value.toUpperCase();
			gbcity=city;
			}
			if(document.getElementById('txtcountry').value=="0")
		    {
		    var country= "";
		    gbcountry=country;
		    }
		    else{
		    var country= document.getElementById('txtcountry').value.toUpperCase();
		    gbcountry=country;
		    }
		    var pubcenter="";
		    if(document.getElementById('drppubcenter').value=="0")
		    {
		        pubcenter="";
		    }
		    else
		    {
		        pubcenter=document.getElementById('drppubcenter').value;
		    }
		    gbpubcenter=pubcenter;
		var dateformat=document.getElementById('hiddenDateFormat').value; 
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
BranchMaster.exebranch(compcode,userid,branchcode,branchname,alias,country,city,pubcenter,dateformat,callexe)
		
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
			        setButtonImages();	
		        if(document.getElementById('btnModify').disabled==false)					
		           document.getElementById('btnModify').focus();	
                        
                        document.getElementById('drppubcenter').disabled=true;        						
						document.getElementById('txtbranchcode').disabled=true;
						document.getElementById('txtbranchname').disabled=true;
						document.getElementById('txtalias').disabled=true;
						document.getElementById('txtaddress').disabled=true;
						document.getElementById('txtstreet').disabled=true;
						document.getElementById('drpcity').disabled=true;
						document.getElementById('txtdist').disabled=true;
						document.getElementById('txtstate').disabled=true;
						document.getElementById('txtcountry').disabled=true;
						document.getElementById('txtfax').disabled=true;
						document.getElementById('txtpin').disabled=true;
						document.getElementById('txtphone2').disabled=true;
						document.getElementById('txtphone1').disabled=true;
						
						document.getElementById('txtfinphone1').disabled=true;
			document.getElementById('txtfinphone2').disabled=true;
			document.getElementById('txtcollphone1').disabled=true;
			document.getElementById('txtcollphone2').disabled=true;
			document.getElementById('txtcirphone1').disabled=true;
			document.getElementById('txtcirphone2').disabled=true;
			document.getElementById('txtnpphone1').disabled=true;
			document.getElementById('txtnpphone2').disabled=true;
			document.getElementById('txtstphone1').disabled=true;
			document.getElementById('txtstphone2').disabled=true;
						
						
						document.getElementById('txtemail').disabled=true;
						document.getElementById('drpzone').disabled=true;
			            document.getElementById('drpregion').disabled=true;
	
							
		return false;
		}
		
	
	
	function callexe(res)
	{
	    dsbranchexecute=res.value;
	    if(dsbranchexecute==null)
			{
			    alert(res.error.description);
			    return false;
			}   
	    if(dsbranchexecute.Tables[0].Rows.length>0)
	    {
	
			document.getElementById('txtbranchcode').value=trim(dsbranchexecute.Tables[0].Rows[0].Branch_Code);
			document.getElementById('txtbranchname').value=dsbranchexecute.Tables[0].Rows[0].Branch_Name;
			document.getElementById('txtalias').value=dsbranchexecute.Tables[0].Rows[0].Branch_Alias;
			if(dsbranchexecute.Tables[0].Rows[0].Add1== null)
			{
			document.getElementById('txtaddress').value="";
			}
			else
			{
			document.getElementById('txtaddress').value=dsbranchexecute.Tables[0].Rows[0].Add1;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Street== null)
			{
			document.getElementById('txtstreet').value="";
			}
			else
			{
			document.getElementById('txtstreet').value=dsbranchexecute.Tables[0].Rows[0].Street;
			}
			//document.getElementById('drpcity').value=ds.Tables[0].Rows[0].City_Code;
			if(dsbranchexecute.Tables[0].Rows[0].Dist_Code== null)
			{
			document.getElementById('txtdist').value="";
			}
			else
			{
			document.getElementById('txtdist').value=dsbranchexecute.Tables[0].Rows[0].Dist_Code;
			}
			document.getElementById('txtstate').value=dsbranchexecute.Tables[0].Rows[0].State_Code;
			document.getElementById('txtcountry').value=dsbranchexecute.Tables[0].Rows[0].Country_Code;
			if(dsbranchexecute.Tables[0].Rows[0].Fax== null)
			{
			document.getElementById('txtfax').value="";
			}
			else
			{
			document.getElementById('txtfax').value=dsbranchexecute.Tables[0].Rows[0].Fax;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Zip== null)
			{
			document.getElementById('txtpin').value="";
			}
			else
			{
			document.getElementById('txtpin').value=dsbranchexecute.Tables[0].Rows[0].Zip;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Phone2== null)
			{
			document.getElementById('txtphone2').value="";
			}
			else
			{
			document.getElementById('txtphone2').value=dsbranchexecute.Tables[0].Rows[0].Phone2;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Phone1== null)
			{
			document.getElementById('txtphone1').value="";
			}
			else
			{
			document.getElementById('txtphone1').value=dsbranchexecute.Tables[0].Rows[0].Phone1;
			}
			
			///////// add nre column///////////////
			
			if(dsbranchexecute.Tables[0].Rows[0].FIN_PHONE1== null)
			{
			document.getElementById('txtfinphone1').value="";
			}
			else
			{
			document.getElementById('txtfinphone1').value=dsbranchexecute.Tables[0].Rows[0].FIN_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].FIN_PHONE2== null)
			{
			document.getElementById('txtfinphone2').value="";
			}
			else
			{
			document.getElementById('txtfinphone2').value=dsbranchexecute.Tables[0].Rows[0].FIN_PHONE2;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[0].COLL_PHONE1== null)
			{
			document.getElementById('txtcollphone1').value="";
			}
			else
			{
			document.getElementById('txtcollphone1').value=dsbranchexecute.Tables[0].Rows[0].COLL_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].COLL_PHONE2== null)
			{
			document.getElementById('txtcollphone2').value="";
			}
			else
			{
			document.getElementById('txtcollphone2').value=dsbranchexecute.Tables[0].Rows[0].COLL_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].CIR_PHONE1== null)
			{
			document.getElementById('txtcirphone1').value="";
			}
			else
			{
			document.getElementById('txtcirphone1').value=dsbranchexecute.Tables[0].Rows[0].CIR_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].CIR_PHONE2== null)
			{
			document.getElementById('txtcirphone2').value="";
			}
			else
			{
			document.getElementById('txtcirphone2').value=dsbranchexecute.Tables[0].Rows[0].CIR_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].NP_PHONE1== null)
			{
			document.getElementById('txtnpphone1').value="";
			}
			else
			{
			document.getElementById('txtnpphone1').value=dsbranchexecute.Tables[0].Rows[0].NP_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].NP_PHONE2== null)
			{
			document.getElementById('txtnpphone2').value="";
			}
			else
			{
			document.getElementById('txtnpphone2').value=dsbranchexecute.Tables[0].Rows[0].NP_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].ST_PHONE1== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone1').value=dsbranchexecute.Tables[0].Rows[0].ST_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].ST_PHONE2== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone2').value=dsbranchexecute.Tables[0].Rows[0].ST_PHONE2;
			}
			
			
			////////////////end////////////////////////
			if(dsbranchexecute.Tables[0].Rows[0].EmailID== null)
			{
			document.getElementById('txtemail').value="";
			}
			else
			{
			document.getElementById('txtemail').value=dsbranchexecute.Tables[0].Rows[0].EmailID;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Region_code== null)
			{
			document.getElementById('drpregion').value="0";
			}
			else
			{
			document.getElementById('drpregion').value=dsbranchexecute.Tables[0].Rows[0].Region_code;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Zone_code== null)
			{
			document.getElementById('drpzone').value="0";
			}
			else
			{
			document.getElementById('drpzone').value=dsbranchexecute.Tables[0].Rows[0].Zone_code;
			}
			document.getElementById('drppubcenter').value=dsbranchexecute.Tables[0].Rows[0].pub_center;
			if(dsbranchexecute.Tables[0].Rows[0].BOX_ADDRESS== null)
			{
			document.getElementById('txtboxadd').value="";
			}
			else
			{
			document.getElementById('txtboxadd').value=dsbranchexecute.Tables[0].Rows[0].BOX_ADDRESS;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].BRANCH_NICK== null)
			{
			document.getElementById('Textnick').value="";
			}
			else
			{
			document.getElementById('Textnick').value=dsbranchexecute.Tables[0].Rows[0].BRANCH_NICK;
			}
			
		    if (dsbranchexecute.Tables[0].Rows[0].INTEGRATION_ID == "null" || dsbranchexecute.Tables[0].Rows[0].INTEGRATION_ID == null) {
               document.getElementById('txtintegration').value = "";
            }
            else {
               document.getElementById('txtintegration').value = dsbranchexecute.Tables[0].Rows[0].INTEGRATION_ID;
		    }

		    if (dsbranchexecute.Tables[0].Rows[0].GSTIN == "null" || dsbranchexecute.Tables[0].Rows[0].GSTIN == null) {
		        document.getElementById('txtGSTIN').value = "";
		    }
		    else {
		        document.getElementById('txtGSTIN').value = dsbranchexecute.Tables[0].Rows[0].GSTIN;
		    }
            ////////////////////////////////////
		    if (dsbranchexecute.Tables[0].Rows[0].PAN_NO == "null" || dsbranchexecute.Tables[0].Rows[0].PAN_NO == null) {
		        document.getElementById('txtpanno').value = "";
		    }
		    else {
		        document.getElementById('txtpanno').value = dsbranchexecute.Tables[0].Rows[0].PAN_NO;
		    }

		    if (dsbranchexecute.Tables[0].Rows[0].AC_HOLDER == "null" || dsbranchexecute.Tables[0].Rows[0].AC_HOLDER == null) {
		        document.getElementById('txtholder').value = "";
		    }
		    else {
		        document.getElementById('txtholder').value = dsbranchexecute.Tables[0].Rows[0].AC_HOLDER;
		    }

		    if (dsbranchexecute.Tables[0].Rows[0].BANK_NAME == "null" || dsbranchexecute.Tables[0].Rows[0].BANK_NAME == null) {
		        document.getElementById('txtbankname').value = "";
		    }
		    else {
		        document.getElementById('txtbankname').value = dsbranchexecute.Tables[0].Rows[0].BANK_NAME;
		    }

		    if (dsbranchexecute.Tables[0].Rows[0].BANK_ACCOUNT == "null" || dsbranchexecute.Tables[0].Rows[0].BANK_ACCOUNT == null) {
		        document.getElementById('txtbankacount').value = "";
		    }
		    else {
		        document.getElementById('txtbankacount').value = dsbranchexecute.Tables[0].Rows[0].BANK_ACCOUNT;
		    }

		    if (dsbranchexecute.Tables[0].Rows[0].BANK_BRANCH_CODE == "null" || dsbranchexecute.Tables[0].Rows[0].BANK_BRANCH_CODE == null) {
		        document.getElementById('txtbankbranch').value = "";
		    }
		    else {
		        document.getElementById('txtbankbranch').value = dsbranchexecute.Tables[0].Rows[0].BANK_BRANCH_CODE;
		    }

		    if (dsbranchexecute.Tables[0].Rows[0].BANK_CITY_CODE == "null" || dsbranchexecute.Tables[0].Rows[0].BANK_CITY_CODE == null) {
		        document.getElementById('txtbankcity').value = "";
		    }
		    else {
		        document.getElementById('txtbankcity').value = dsbranchexecute.Tables[0].Rows[0].BANK_CITY_CODE;
		    }
			

		    if (dsbranchexecute.Tables[0].Rows[0].BANK_IFSC_CODE == "null" || dsbranchexecute.Tables[0].Rows[0].BANK_IFSC_CODE == null) {
		        document.getElementById('txtifsc').value = "";
		    }
		    else {
		        document.getElementById('txtifsc').value = dsbranchexecute.Tables[0].Rows[0].BANK_IFSC_CODE;
		    }
			
			addcount_branch(dsbranchexecute.Tables[0].Rows[0].Country_Code);
				cityvar=dsbranchexecute.Tables[0].Rows[0].City_Code;
			
			document.getElementById('lbcontdetails').disabled = false;
			
			if(dsbranchexecute.Tables[0].Rows.length==1)
		    {
		    document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
		    }
		    setButtonImages();
	return false;
	}
	else
	{
	alert("Your Search Criteria Does Not  Exist");
	
	('BranchMaster');
	return false;
	}
	setButtonImages();
	return false;
	}



function brfirst()
{
 var msg=checkSession();
        if(msg==false)
        return false;
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

BranchMaster.blanksession();
			var userid= document.getElementById('hiddenuserid').value;
			var compcode= document.getElementById('hiddencompcode').value;
//			BranchMaster.fnplbranch(compcode,userid,firstcall)
//			
//			
//			return false;
//}

//function firstcall(response)
//{
			z=0;
			//ds=response.value;
			
			document.getElementById('txtbranchcode').value=trim(dsbranchexecute.Tables[0].Rows[0].Branch_Code);
			document.getElementById('txtbranchname').value=dsbranchexecute.Tables[0].Rows[0].Branch_Name;
			document.getElementById('txtalias').value=dsbranchexecute.Tables[0].Rows[0].Branch_Alias;
			if(dsbranchexecute.Tables[0].Rows[0].Add1== null)
			{
			document.getElementById('txtaddress').value="";
			}
			else
			{
			document.getElementById('txtaddress').value=dsbranchexecute.Tables[0].Rows[0].Add1;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Street== null)
			{
			document.getElementById('txtstreet').value="";
			}
			else
			{
			document.getElementById('txtstreet').value=dsbranchexecute.Tables[0].Rows[0].Street;
			}
			//document.getElementById('drpcity').value=dsbranchexecute.Tables[0].Rows[0].City_Code;
			if(dsbranchexecute.Tables[0].Rows[0].Dist_Code== null)
			{
			document.getElementById('txtdist').value="";
			}
			else
			{
			document.getElementById('txtdist').value=dsbranchexecute.Tables[0].Rows[0].Dist_Code;
			}
			document.getElementById('txtstate').value=dsbranchexecute.Tables[0].Rows[0].State_Code;
			document.getElementById('txtcountry').value=dsbranchexecute.Tables[0].Rows[0].Country_Code;
			if(dsbranchexecute.Tables[0].Rows[0].Fax== null)
			{
			document.getElementById('txtfax').value="";
			}
			else
			{
			document.getElementById('txtfax').value=dsbranchexecute.Tables[0].Rows[0].Fax;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Zip== null)
			{
			document.getElementById('txtpin').value="";
			}
			else
			{
			document.getElementById('txtpin').value=dsbranchexecute.Tables[0].Rows[0].Zip;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Phone2== null)
			{
			document.getElementById('txtphone2').value="";
			}
			else
			{
			document.getElementById('txtphone2').value=dsbranchexecute.Tables[0].Rows[0].Phone2;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Phone1== null)
			{
			document.getElementById('txtphone1').value="";
			}
			else
			{
			document.getElementById('txtphone1').value=dsbranchexecute.Tables[0].Rows[0].Phone1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].FIN_PHONE1== null)
			{
			document.getElementById('txtfinphone1').value="";
			}
			else
			{
			document.getElementById('txtfinphone1').value=dsbranchexecute.Tables[0].Rows[0].FIN_PHONE1;
			}
			
			//////////////////////////////add new coumn////////////////////////////
			if(dsbranchexecute.Tables[0].Rows[0].FIN_PHONE2== null)
			{
			document.getElementById('txtfinphone2').value="";
			}
			else
			{
			document.getElementById('txtfinphone2').value=dsbranchexecute.Tables[0].Rows[0].FIN_PHONE2;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[0].COLL_PHONE1== null)
			{
			document.getElementById('txtcollphone1').value="";
			}
			else
			{
			document.getElementById('txtcollphone1').value=dsbranchexecute.Tables[0].Rows[0].COLL_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].COLL_PHONE2== null)
			{
			document.getElementById('txtcollphone2').value="";
			}
			else
			{
			document.getElementById('txtcollphone2').value=dsbranchexecute.Tables[0].Rows[0].COLL_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].CIR_PHONE1== null)
			{
			document.getElementById('txtcirphone1').value="";
			}
			else
			{
			document.getElementById('txtcirphone1').value=dsbranchexecute.Tables[0].Rows[0].CIR_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].CIR_PHONE2== null)
			{
			document.getElementById('txtcirphone2').value="";
			}
			else
			{
			document.getElementById('txtcirphone2').value=dsbranchexecute.Tables[0].Rows[0].CIR_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].NP_PHONE1== null)
			{
			document.getElementById('txtnpphone1').value="";
			}
			else
			{
			document.getElementById('txtnpphone1').value=dsbranchexecute.Tables[0].Rows[0].NP_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].NP_PHONE2== null)
			{
			document.getElementById('txtnpphone2').value="";
			}
			else
			{
			document.getElementById('txtnpphone2').value=dsbranchexecute.Tables[0].Rows[0].NP_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].ST_PHONE1== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone1').value=dsbranchexecute.Tables[0].Rows[0].ST_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].ST_PHONE2== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone2').value=dsbranchexecute.Tables[0].Rows[0].ST_PHONE2;
			}
			///////////////////////end//////////////////
			
			
			if(dsbranchexecute.Tables[0].Rows[0].EmailID== null)
			{
			document.getElementById('txtemail').value="";
			}
			else
			{
			document.getElementById('txtemail').value=dsbranchexecute.Tables[0].Rows[0].EmailID;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].Region_code== null)
			{
			document.getElementById('drpregion').value="0";
			}
			else
			{
			document.getElementById('drpregion').value=dsbranchexecute.Tables[0].Rows[0].Region_code;
			}
			if(dsbranchexecute.Tables[0].Rows[0].Zone_code== null)
			{
			document.getElementById('drpzone').value="0";
			}
			else
			{
			document.getElementById('drpzone').value=dsbranchexecute.Tables[0].Rows[0].Zone_code;
			}
			if(dsbranchexecute.Tables[0].Rows[0].BOX_ADDRESS== null)
			{
			document.getElementById('txtboxadd').value="";
			}
			else
			{
			document.getElementById('txtboxadd').value=dsbranchexecute.Tables[0].Rows[0].BOX_ADDRESS;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[0].BRANCH_NICK== null)
			{
			document.getElementById('Textnick').value="";
			}
			else
			{
			document.getElementById('Textnick').value=dsbranchexecute.Tables[0].Rows[0].BRANCH_NICK;
			}
			
			if(dsbranchexecute.Tables[0].Rows[0].INTEGRATION_ID== null)
			{
			document.getElementById('txtintegration').value="";
			}
			else
			{
			document.getElementById('txtintegration').value=dsbranchexecute.Tables[0].Rows[0].INTEGRATION_ID;
			}
			
			
			document.getElementById('drppubcenter').value=dsbranchexecute.Tables[0].Rows[0].pub_center;
			
				cityvar=dsbranchexecute.Tables[0].Rows[0].City_Code;
			addcount_branch(dsbranchexecute.Tables[0].Rows[0].Country_Code);
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


function brpre()
{
 var msg=checkSession();
        if(msg==false)
        return false;
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

BranchMaster.blanksession();
			var userid= document.getElementById('hiddenuserid').value;
			var compcode= document.getElementById('hiddencompcode').value;
//			BranchMaster.fnplbranch(compcode,userid,precall)
//			return false;
//}

//function precall(response)
//{
	z--;
	//dsbranchexecute=response.value;
	var x=dsbranchexecute.Tables[0].Rows.length;
	
	

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
		if(dsbranchexecute.Tables[0].Rows.length != z)
		{
			document.getElementById('txtbranchcode').value=trim(dsbranchexecute.Tables[0].Rows[z].Branch_Code);
			document.getElementById('txtbranchname').value=dsbranchexecute.Tables[0].Rows[z].Branch_Name;
			document.getElementById('txtalias').value=dsbranchexecute.Tables[0].Rows[z].Branch_Alias;
			if(dsbranchexecute.Tables[0].Rows[z].Add1== null)
			{
			document.getElementById('txtaddress').value="";
			}
			else
			{
			document.getElementById('txtaddress').value=dsbranchexecute.Tables[0].Rows[z].Add1;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Street== null)
			{
			document.getElementById('txtstreet').value="";
			}
			else
			{
			document.getElementById('txtstreet').value=dsbranchexecute.Tables[0].Rows[z].Street;
			}
			document.getElementById('drpcity').value=dsbranchexecute.Tables[0].Rows[z].City_Code;
			if(dsbranchexecute.Tables[0].Rows[z].Dist_Code== null)
			{
			document.getElementById('txtdist').value="";
			}
			else
			{
			document.getElementById('txtdist').value=dsbranchexecute.Tables[0].Rows[z].Dist_Code;
			}
			document.getElementById('txtstate').value=dsbranchexecute.Tables[0].Rows[z].State_Code;
			document.getElementById('txtcountry').value=dsbranchexecute.Tables[0].Rows[z].Country_Code;
			if(dsbranchexecute.Tables[0].Rows[z].Fax== null)
			{
			document.getElementById('txtfax').value="";
			}
			else
			{
			document.getElementById('txtfax').value=dsbranchexecute.Tables[0].Rows[z].Fax;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Zip== null)
			{
			document.getElementById('txtpin').value="";
			}
			else
			{
			document.getElementById('txtpin').value=dsbranchexecute.Tables[0].Rows[z].Zip;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Phone2== null)
			{
			document.getElementById('txtphone2').value="";
			}
			else
			{
			document.getElementById('txtphone2').value=dsbranchexecute.Tables[0].Rows[z].Phone2;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Phone1== null)
			{
			document.getElementById('txtphone1').value="";
			}
			else
			{
			document.getElementById('txtphone1').value=dsbranchexecute.Tables[0].Rows[z].Phone1;
			}
			
			//////////////////////////////add new coumn////////////////////////////
			if(dsbranchexecute.Tables[0].Rows[z].FIN_PHONE2== null)
			{
			document.getElementById('txtfinphone2').value="";
			}
			else
			{
			document.getElementById('txtfinphone2').value=dsbranchexecute.Tables[0].Rows[z].FIN_PHONE2;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[z].COLL_PHONE1== null)
			{
			document.getElementById('txtcollphone1').value="";
			}
			else
			{
			document.getElementById('txtcollphone1').value=dsbranchexecute.Tables[0].Rows[z].COLL_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].COLL_PHONE2== null)
			{
			document.getElementById('txtcollphone2').value="";
			}
			else
			{
			document.getElementById('txtcollphone2').value=dsbranchexecute.Tables[0].Rows[z].COLL_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].CIR_PHONE1== null)
			{
			document.getElementById('txtcirphone1').value="";
			}
			else
			{
			document.getElementById('txtcirphone1').value=dsbranchexecute.Tables[0].Rows[z].CIR_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].CIR_PHONE2== null)
			{
			document.getElementById('txtcirphone2').value="";
			}
			else
			{
			document.getElementById('txtcirphone2').value=dsbranchexecute.Tables[0].Rows[z].CIR_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].NP_PHONE1== null)
			{
			document.getElementById('txtnpphone1').value="";
			}
			else
			{
			document.getElementById('txtnpphone1').value=dsbranchexecute.Tables[0].Rows[z].NP_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].NP_PHONE2== null)
			{
			document.getElementById('txtnpphone2').value="";
			}
			else
			{
			document.getElementById('txtnpphone2').value=dsbranchexecute.Tables[0].Rows[z].NP_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].ST_PHONE1== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone1').value=dsbranchexecute.Tables[0].Rows[z].ST_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].ST_PHONE2== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone2').value=dsbranchexecute.Tables[0].Rows[z].ST_PHONE2;
			}
			///////////////////////end//////////////////
			if(dsbranchexecute.Tables[0].Rows[z].EmailID== null)
			{
			document.getElementById('txtemail').value="";
			}
			else
			{
			document.getElementById('txtemail').value=dsbranchexecute.Tables[0].Rows[z].EmailID;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Region_code== null)
			{
			document.getElementById('drpregion').value="0";
			}
			else
			{
			document.getElementById('drpregion').value=dsbranchexecute.Tables[0].Rows[z].Region_code;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Zone_code== null)
			{
			document.getElementById('drpzone').value="0";
			}
			else
			{
			document.getElementById('drpzone').value=dsbranchexecute.Tables[0].Rows[z].Zone_code;
			}
			if(dsbranchexecute.Tables[0].Rows[z].BOX_ADDRESS== null)
			{
			document.getElementById('txtboxadd').value="";
			}
			else
			{
			document.getElementById('txtboxadd').value=dsbranchexecute.Tables[0].Rows[z].BOX_ADDRESS;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[z].BRANCH_NICK== null)
			{
			document.getElementById('Textnick').value="";
			}
			else
			{
			document.getElementById('Textnick').value=dsbranchexecute.Tables[0].Rows[z].BRANCH_NICK;
			}
			
			
			
			document.getElementById('drppubcenter').value=dsbranchexecute.Tables[0].Rows[z].pub_center;
			
				cityvar=dsbranchexecute.Tables[0].Rows[z].City_Code;
			addcount_branch(dsbranchexecute.Tables[0].Rows[z].Country_Code);
			updateStatus();
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					
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

function brnext()
{
     var msg=checkSession();
        if(msg==false)
        return false;
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

BranchMaster.blanksession();
			var userid= document.getElementById('hiddenuserid').value;
			var compcode= document.getElementById('hiddencompcode').value;
			
//			BranchMaster.fnplbranch(compcode,userid,nextcall)
//			return false;
//}

//function nextcall(response)
//{
	z++;
//	dsbranchexecute=response.value;
	var x=dsbranchexecute.Tables[0].Rows.length;
	if(z <= x && z >= 0)
	{
		if(dsbranchexecute.Tables[0].Rows.length != z && z !=-1)
		{
			document.getElementById('txtbranchcode').value=trim(dsbranchexecute.Tables[0].Rows[z].Branch_Code);
			document.getElementById('txtbranchname').value=dsbranchexecute.Tables[0].Rows[z].Branch_Name;
			document.getElementById('txtalias').value=dsbranchexecute.Tables[0].Rows[z].Branch_Alias;
			if(dsbranchexecute.Tables[0].Rows[z].Add1== null)
			{
			document.getElementById('txtaddress').value="";
			}
			else
			{
			document.getElementById('txtaddress').value=dsbranchexecute.Tables[0].Rows[z].Add1;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Street== null)
			{
			document.getElementById('txtstreet').value="";
			}
			else
			{
			document.getElementById('txtstreet').value=dsbranchexecute.Tables[0].Rows[z].Street;
			}
			document.getElementById('drpcity').value=dsbranchexecute.Tables[0].Rows[z].City_Code;
			if(dsbranchexecute.Tables[0].Rows[z].Dist_Code== null)
			{
			document.getElementById('txtdist').value="";
			}
			else
			{
			document.getElementById('txtdist').value=dsbranchexecute.Tables[0].Rows[z].Dist_Code;
			}
			document.getElementById('txtstate').value=dsbranchexecute.Tables[0].Rows[z].State_Code;
			document.getElementById('txtcountry').value=dsbranchexecute.Tables[0].Rows[z].Country_Code;
			if(dsbranchexecute.Tables[0].Rows[z].Fax== null)
			{
			document.getElementById('txtfax').value="";
			}
			else
			{
			document.getElementById('txtfax').value=dsbranchexecute.Tables[0].Rows[z].Fax;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Zip== null)
			{
			document.getElementById('txtpin').value="";
			}
			else
			{
			document.getElementById('txtpin').value=dsbranchexecute.Tables[0].Rows[z].Zip;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Phone2== null)
			{
			document.getElementById('txtphone2').value="";
			}
			else
			{
			document.getElementById('txtphone2').value=dsbranchexecute.Tables[0].Rows[z].Phone2;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Phone1== null)
			{
			document.getElementById('txtphone1').value="";
			}
			else
			{
			document.getElementById('txtphone1').value=dsbranchexecute.Tables[0].Rows[z].Phone1;
			}
			
				//////////////////////////////add new coumn////////////////////////////
			if(dsbranchexecute.Tables[0].Rows[z].FIN_PHONE2== null)
			{
			document.getElementById('txtfinphone2').value="";
			}
			else
			{
			document.getElementById('txtfinphone2').value=dsbranchexecute.Tables[0].Rows[z].FIN_PHONE2;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[z].COLL_PHONE1== null)
			{
			document.getElementById('txtcollphone1').value="";
			}
			else
			{
			document.getElementById('txtcollphone1').value=dsbranchexecute.Tables[0].Rows[z].COLL_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].COLL_PHONE2== null)
			{
			document.getElementById('txtcollphone2').value="";
			}
			else
			{
			document.getElementById('txtcollphone2').value=dsbranchexecute.Tables[0].Rows[z].COLL_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].CIR_PHONE1== null)
			{
			document.getElementById('txtcirphone1').value="";
			}
			else
			{
			document.getElementById('txtcirphone1').value=dsbranchexecute.Tables[0].Rows[z].CIR_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].CIR_PHONE2== null)
			{
			document.getElementById('txtcirphone2').value="";
			}
			else
			{
			document.getElementById('txtcirphone2').value=dsbranchexecute.Tables[0].Rows[z].CIR_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].NP_PHONE1== null)
			{
			document.getElementById('txtnpphone1').value="";
			}
			else
			{
			document.getElementById('txtnpphone1').value=dsbranchexecute.Tables[0].Rows[z].NP_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].NP_PHONE2== null)
			{
			document.getElementById('txtnpphone2').value="";
			}
			else
			{
			document.getElementById('txtnpphone2').value=dsbranchexecute.Tables[0].Rows[z].NP_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].ST_PHONE1== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone1').value=dsbranchexecute.Tables[0].Rows[z].ST_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[z].ST_PHONE2== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone2').value=dsbranchexecute.Tables[0].Rows[z].ST_PHONE2;
			}
			///////////////////////end//////////////////
			
			if(dsbranchexecute.Tables[0].Rows[z].EmailID== null)
			{
			document.getElementById('txtemail').value="";
			}
			else
			{
			document.getElementById('txtemail').value=dsbranchexecute.Tables[0].Rows[z].EmailID;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Region_code== null)
			{
			document.getElementById('drpregion').value="0";
			}
			else
			{
			document.getElementById('drpregion').value=dsbranchexecute.Tables[0].Rows[z].Region_code;
			}
			if(dsbranchexecute.Tables[0].Rows[z].Zone_code== null)
			{
			document.getElementById('drpzone').value="0";
			}
			else
			{
			document.getElementById('drpzone').value=dsbranchexecute.Tables[0].Rows[z].Zone_code;
			}
			if(dsbranchexecute.Tables[0].Rows[z].BOX_ADDRESS== null)
			{
			document.getElementById('txtboxadd').value="";
			}
			else
			{
			document.getElementById('txtboxadd').value=dsbranchexecute.Tables[0].Rows[z].BOX_ADDRESS;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[z].BRANCH_NICK== null)
			{
			document.getElementById('Textnick').value="";
			}
			else
			{
			document.getElementById('Textnick').value=dsbranchexecute.Tables[0].Rows[z].BRANCH_NICK;
			}
			
			
			
			document.getElementById('drppubcenter').value=dsbranchexecute.Tables[0].Rows[z].pub_center;
			
				cityvar=dsbranchexecute.Tables[0].Rows[z].City_Code;
			addcount_branch(dsbranchexecute.Tables[0].Rows[z].Country_Code);
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
function brlast()
{
 var msg=checkSession();
        if(msg==false)
        return false;
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

            //BranchMaster.blanksession();
			var userid= document.getElementById('hiddenuserid').value;
			var compcode= document.getElementById('hiddencompcode').value;
			
//			BranchMaster.fnplbranch(compcode,userid,lastcall)


//return false;


//}


//function lastcall(response)
//	{

			//ds= response.value;
				var x=dsbranchexecute.Tables[0].Rows.length;
				z=x-1;
				x=x-1;

			document.getElementById('txtbranchcode').value=trim(dsbranchexecute.Tables[0].Rows[x].Branch_Code);
			document.getElementById('txtbranchname').value=dsbranchexecute.Tables[0].Rows[x].Branch_Name;
			document.getElementById('txtalias').value=dsbranchexecute.Tables[0].Rows[x].Branch_Alias;
			if(dsbranchexecute.Tables[0].Rows[x].Add1== null)
			{
			document.getElementById('txtaddress').value="";
			}
			else
			{
			document.getElementById('txtaddress').value=dsbranchexecute.Tables[0].Rows[x].Add1;
			}
			if(dsbranchexecute.Tables[0].Rows[x].Street== null)
			{
			document.getElementById('txtstreet').value="";
			}
			else
			{
			document.getElementById('txtstreet').value=dsbranchexecute.Tables[0].Rows[x].Street;
			}
			document.getElementById('drpcity').value=dsbranchexecute.Tables[0].Rows[x].City_Code;
			if(dsbranchexecute.Tables[0].Rows[x].Dist_Code== null)
			{
			document.getElementById('txtdist').value="";
			}
			else
			{
			document.getElementById('txtdist').value=dsbranchexecute.Tables[0].Rows[x].Dist_Code;
			}
			document.getElementById('txtstate').value=dsbranchexecute.Tables[0].Rows[x].State_Code;
			document.getElementById('txtcountry').value=dsbranchexecute.Tables[0].Rows[x].Country_Code;
			if(dsbranchexecute.Tables[0].Rows[x].Fax== null)
			{
			document.getElementById('txtfax').value="";
			}
			else
			{
			document.getElementById('txtfax').value=dsbranchexecute.Tables[0].Rows[x].Fax;
			}
			if(dsbranchexecute.Tables[0].Rows[x].Zip== null)
			{
			document.getElementById('txtpin').value="";
			}
			else
			{
			document.getElementById('txtpin').value=dsbranchexecute.Tables[0].Rows[x].Zip;
			}
			if(dsbranchexecute.Tables[0].Rows[x].Phone2== null)
			{
			document.getElementById('txtphone2').value="";
			}
			else
			{
			document.getElementById('txtphone2').value=dsbranchexecute.Tables[0].Rows[x].Phone2;
			}
			if(dsbranchexecute.Tables[0].Rows[x].Phone1== null)
			{
			document.getElementById('txtphone1').value="";
			}
			else
			{
			document.getElementById('txtphone1').value=dsbranchexecute.Tables[0].Rows[x].Phone1;
			}
			if(dsbranchexecute.Tables[0].Rows[x].EmailID== null)
			{
				//////////////////////////////add new coumn////////////////////////////
			if(dsbranchexecute.Tables[0].Rows[x].FIN_PHONE2== null)
			{
			document.getElementById('txtfinphone2').value="";
			}
			else
			{
			document.getElementById('txtfinphone2').value=dsbranchexecute.Tables[0].Rows[x].FIN_PHONE2;
			}
			
			
			if(dsbranchexecute.Tables[0].Rows[x].COLL_PHONE1== null)
			{
			document.getElementById('txtcollphone1').value="";
			}
			else
			{
			document.getElementById('txtcollphone1').value=dsbranchexecute.Tables[0].Rows[x].COLL_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].COLL_PHONE2== null)
			{
			document.getElementById('txtcollphone2').value="";
			}
			else
			{
			document.getElementById('txtcollphone2').value=dsbranchexecute.Tables[0].Rows[x].COLL_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].CIR_PHONE1== null)
			{
			document.getElementById('txtcirphone1').value="";
			}
			else
			{
			document.getElementById('txtcirphone1').value=dsbranchexecute.Tables[0].Rows[x].CIR_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].CIR_PHONE2== null)
			{
			document.getElementById('txtcirphone2').value="";
			}
			else
			{
			document.getElementById('txtcirphone2').value=dsbranchexecute.Tables[0].Rows[x].CIR_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].NP_PHONE1== null)
			{
			document.getElementById('txtnpphone1').value="";
			}
			else
			{
			document.getElementById('txtnpphone1').value=dsbranchexecute.Tables[0].Rows[x].NP_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].NP_PHONE2== null)
			{
			document.getElementById('txtnpphone2').value="";
			}
			else
			{
			document.getElementById('txtnpphone2').value=dsbranchexecute.Tables[0].Rows[x].NP_PHONE2;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].ST_PHONE1== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone1').value=dsbranchexecute.Tables[0].Rows[x].ST_PHONE1;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].ST_PHONE2== null)
			{
			document.getElementById('txtstphone1').value="";
			}
			else
			{
			document.getElementById('txtstphone2').value=dsbranchexecute.Tables[0].Rows[x].ST_PHONE2;
			}
			///////////////////////end//////////////////
			
			document.getElementById('txtemail').value="";
			}
			else
			{
			document.getElementById('txtemail').value=dsbranchexecute.Tables[0].Rows[x].EmailID;
			}
			if(dsbranchexecute.Tables[0].Rows[x].Region_code== null)
			{
			document.getElementById('drpregion').value="0";
			}
			else
			{
			document.getElementById('drpregion').value=dsbranchexecute.Tables[0].Rows[x].Region_code;
			}
			if(dsbranchexecute.Tables[0].Rows[x].Zone_code== null)
			{
			document.getElementById('drpzone').value="0";
			}
			else
			{
			document.getElementById('drpzone').value=dsbranchexecute.Tables[0].Rows[x].Zone_code;
			}
			if(dsbranchexecute.Tables[0].Rows[x].BOX_ADDRESS== null)
			{
			document.getElementById('txtboxadd').value="";
			}
			else
			{
			document.getElementById('txtboxadd').value=dsbranchexecute.Tables[0].Rows[x].BOX_ADDRESS;
			}
			
			if(dsbranchexecute.Tables[0].Rows[x].BRANCH_NICK== null)
			{
			document.getElementById('Textnick').value="";
			}
			else
			{
			document.getElementById('Textnick').value=dsbranchexecute.Tables[0].Rows[x].BRANCH_NICK;
			}
			
			
			
			
			document.getElementById('drppubcenter').value=dsbranchexecute.Tables[0].Rows[x].pub_center;
			
				cityvar=dsbranchexecute.Tables[0].Rows[x].City_Code;
			addcount_branch(dsbranchexecute.Tables[0].Rows[x].Country_Code);
					
			    updateStatus();
		
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
	return false;
	}
	
	
function brcancle(formname)
{  
      ///chkstatus(FlagStatus);
      //givebuttonpermission(formname);
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

       BranchMaster.blanksession();
            document.getElementById('hiddensubmod').value="0";
				document.getElementById('btnNew').disabled=false;
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
				show="0";
				
				//getPermission('BranchMaster');
				
					givebuttonpermission(formname);
	
				document.getElementById('drppubcenter').disabled=true;
				document.getElementById('txtbranchcode').disabled=true;
				document.getElementById('txtbranchname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtaddress').disabled=true;
				document.getElementById('txtstreet').disabled=true;
				document.getElementById('drpcity').disabled=true;
				document.getElementById('txtdist').disabled=true;
				document.getElementById('txtstate').disabled=true;
				document.getElementById('txtcountry').disabled=true;
				document.getElementById('txtfax').disabled=true;
				document.getElementById('txtpin').disabled=true;
				document.getElementById('txtphone2').disabled=true;
				document.getElementById('txtphone1').disabled=true;
				document.getElementById('txtemail').disabled=true;
				document.getElementById('drpregion').disabled=true;
				document.getElementById('drpzone').disabled=true;
				document.getElementById('lbcontdetails').disabled=true;
				document.getElementById('txtboxadd').disabled=true;
				document.getElementById('Textnick').disabled=true;
				document.getElementById('txtintegration').disabled = true;
		        document.getElementById('drppubcenter').value="0";
				document.getElementById('txtbranchcode').value="";
				document.getElementById('txtbranchname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('txtaddress').value="";
				document.getElementById('txtstreet').value="";
				document.getElementById('drpcity').value="0";
				document.getElementById('txtdist').value="";
				document.getElementById('txtstate').value="";
				document.getElementById('txtcountry').value="0";
				document.getElementById('txtfax').value="";
				document.getElementById('txtpin').value="";
				document.getElementById('txtphone2').value="";
				document.getElementById('txtphone1').value="";
				document.getElementById('txtfinphone1').value="";
			document.getElementById('txtfinphone2').value="";
			document.getElementById('txtcollphone1').value="";
			document.getElementById('txtcollphone2').value="";
			document.getElementById('txtcirphone1').value="";
			document.getElementById('txtcirphone2').value="";
			document.getElementById('txtnpphone1').value="";
			document.getElementById('txtnpphone2').value="";
			document.getElementById('txtstphone1').value="";
			document.getElementById('txtstphone2').value="";
				document.getElementById('txtemail').value="";
				document.getElementById('drpregion').value="0";
				document.getElementById('drpzone').value="0";
				document.getElementById('txtboxadd').value="";
				document.getElementById('Textnick').value = "";
				document.getElementById('txtintegration').value = "";
    //////////////////////////////
				document.getElementById('txtGSTIN').value = "";
				document.getElementById('txtpanno').value = "";
				document.getElementById('txtholder').value = "";
				document.getElementById('txtbankname').value = "";
				document.getElementById('txtbankacount').value = "";
				document.getElementById('txtbankbranch').value = "";
				document.getElementById('txtbankcity').value = "";
				document.getElementById('txtifsc').value = "";

    ///////////////////////////////
				setButtonImages();
				if(document.getElementById('btnNew').disabled==false)
				   document.getElementById('btnNew').focus();
		
	
				return false;
}
	
function brexit()
{
	if(confirm ("Do You Want To Skip This Page"))
	{
	
//		if(typeof(winid)!="undefined")
//		{
//		winid.close();
//		}	
		window.close();
		return false;
	}
return false;
}
	
			
function checkEmail() 
{
var theurl=document.getElementById('txtemail').value;

if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById('txtemail').value=="")
{
return true;
}
alert("Invalid E-mail Address! Please re-enter.")
document.getElementById('txtemail').value="";
document.getElementById('txtemail').focus();
return false;
}

function openpopup()
{
//userdefine();
if(hiddentext=="new")
{
  checkcode();
  
}
if(hiddentext=="new")
{
    var ds=res2.value;
	var newstr;
		if(ds==null)
		{ 
		 return false;
		}
	    if(ds.Tables[1].Rows.length!=0 )//&& ds1.Tables[1].Rows.length!=0)
	    {
		    alert("This Branch code has already been assigned !! ");
		     document.getElementById('txtbranchcode').value="";
		     //document.getElementById('txtalias').value="";
		     if(document.getElementById('txtbranchcode').disabled==false)
		        document.getElementById('txtbranchcode').focus();
		      return false;
		 }
		 }
var branchcode= document.getElementById('txtbranchcode').value;
var ab;
if(	document.getElementById('lbcontdetails').disabled == false)	
{   
    if(document.getElementById('drppubcenter').value=="0" || document.getElementById('drppubcenter').value=="")
	    {
	        alert('Please Enter Publication Center');
	        document.getElementById('drppubcenter').focus();
	        return false;
	    }
	else if((document.getElementById('hiddenauto').value!=1) && (document.getElementById('txtbranchcode').value==""))
	{
	alert('Please Enter Branch Code');
	document.getElementById('txtbranchcode').focus();
	return false;
	}
	else if (document.getElementById('txtbranchname').value=="")
	{
	alert('Please Enter Branch Name');
	document.getElementById('txtbranchname').focus();
	return false;
	}
    else if(trim(document.getElementById('txtalias').value)== "" )
	        {   
		        alert('Please Enter Alias');
	            document.getElementById('txtalias').focus();
	            return false;
	        }
	   
	else if(trim(document.getElementById('txtaddress').value)== "" )
	        {   
		        alert('Please Enter Address ');
	            document.getElementById('txtaddress').focus();
	            return false;
	        }
	   
	else if(document.getElementById('txtcountry').value == "0" || document.getElementById('txtcountry').value == "")
	        {   
		        alert('Please Enter Country');
	            document.getElementById('txtcountry').focus();
	            return false;
	        }
	  
	else if(document.getElementById('drpcity').value == "0" || document.getElementById('drpcity').value=="")
	        {   
		        alert('Please Enter City');
	            document.getElementById('drpcity').focus();
	            return false;
	        }
	else
	{
	var winid="";
	    for ( var index = 0; index < 200; index++ ) 
               { 
               
              // popbranch=window.open('BranchDetails.aspx?branchcode='+branchcode+'  &show='+show,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px');
              winid=window.open('BranchDetails.aspx?branchcode='+branchcode+'  &show='+show,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px');
            //   window.location=window.location;
               winid.focus();
                 return false;
	      }
                //popbranch.focus();
                

//	        paywind=window.open("BranchDetails.aspx?branchcode="+branchcode+"&show="+show,'c',"status=0,toolbar=0,menubar=0 ,resizable=1,top=244,left=210,width=780px,height=415px");
//        	
//	        paywind.focus();
	        //alert(paywind);
	      
	       return false;
	}
	
}
}

var code10;

function closecontact()
{
//document.getElementById('cl').checked=false;

document.getElementById('txtcontactperson').value="";
document.getElementById('txtdesignation').value="";
document.getElementById('txtdob').value="";
document.getElementById('txtphoneno').value="";
document.getElementById('txtext').value=""; 
document.getElementById('txtfaxno').value="";
document.getElementById('txtemail').value="";
//codeexe="";
window.close();
return ;
}
function clearcontact()
{
//document.getElementById('cl').checked=false;
flag1="0";
document.getElementById('hiddenccode').value="";
document.getElementById('txtcontactperson').value="";
document.getElementById('txtdesignation').value="";
document.getElementById('txtdob').value="";
document.getElementById('txtphoneno').value="";
document.getElementById('txtext').value=""; 
document.getElementById('txtfaxno').value="";
document.getElementById('txtemail').value="";
//codeexe="";

if(((document.getElementById('btndelete').disabled==true) && (document.getElementById('Button1').disabled==true))||((document.getElementById('btndelete').disabled==false) && (document.getElementById('Button1').disabled==false)))
{

var j;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
	document.getElementById('btndelete').disabled=true;
	 if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('Button1').disabled=true;
       }
       else
       {
            document.getElementById('Button1').disabled=false;
       }
	}
}

window.location=window.location;
return ;
}
function submitcontact()
{

    bc=document.getElementById('ContactPerson').innerHTML; 
    
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtcontactperson').value)== "" )
	        { 
	         var srr=bc.replace('<FONT color=red>*</FONT>', "");
	          srr=bc.replace('<FONT color=red>*</FONT>', "");
	          
		        alert('Please Enter '+ srr);
	            document.getElementById('txtcontactperson').focus();
	            return false;
	        }
	    }
	    
    bc=document.getElementById('Designation').innerHTML; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtdesignation').value)== "" )
	        {   
	             var srr=bc.replace('<FONT color=red>*</FONT>', "");
	            srr=bc.replace('<FONT color=red>*</FONT>', "");
	            
		        alert('Please Enter '+ srr);
	            document.getElementById('txtdesignation').focus();
	            return false;
	        }
	    }
	    
    bc=document.getElementById('PhoneNo').innerHTML; 
    if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtphoneno').value)== "" )
	        {   
	           var srr=bc.replace('<FONT color=red>*</FONT>', "");
	           srr=bc.replace('<FONT color=red>*</FONT>', "");
	           alert('Please Enter '+ srr);
	           document.getElementById('txtphoneno').focus();
	           return false;
	        }
	    }
		
//var saur=document.getElementById('txtdob').value;
	

var contactperson=trim(document.getElementById('txtcontactperson').value);
var txtdesignation=trim(document.getElementById('txtdesignation').value);
var txtdob=document.getElementById('txtdob').value;
var txtphoneno=document.getElementById('txtphoneno').value;
var txtext=document.getElementById('txtext').value; 
var txtfaxno=document.getElementById('txtfaxno').value;
var mail=trim(document.getElementById('txtemail').value);
var branchcode=document.getElementById('hiddenbranchcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var hiddenccode=document.getElementById('hiddenccode').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var txtdob="";

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdob').value != "")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
txtdob=mm+'/'+dd+'/'+yy;
}
else
{
txtdob=document.getElementById('txtdob').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdob').value!="")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
txtdob=mm+'/'+dd+'/'+yy;
}
else
{
txtdob=document.getElementById('txtdob').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
txtdob=document.getElementById('txtdob').value;
}

    var du=new Date(txtdob);
    var dc=new Date();
    if(dc<du)
    {
        alert("Date of Birth Sholud Be Less Than Today's date ");
        document.getElementById('txtdob').value="";
        document.getElementById('txtdob').focus();
        return false;
    }

	
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtdob=document.getElementById('txtdob').value;
}
   var hidden=document.getElementById('hiddenDup');
		  
		   if(hidden.value!="")
		   {
		        var hiddata=hidden.value;
		        var arr=hiddata.split(",");
		    
		        for(var a=0;a<arr.length;a++)
		        {
    		        if(arr[a]==document.getElementById('txtcontactperson').value)
	    	        {
		                alert('This contact name already exists');
		                return false;
		            }
		        }
		   }
if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
{
	           
			// BranchDetails.chksubmitcontact(contactperson,branchcode,callsubmitcontact);
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
BranchDetails.chksubmitcontactupdate(contactperson,branchcode,callsubmitcontact);

          //    BranchDetails.submitcontact(contactperson,txtdesignation,txtdob,txtphoneno,txtext,txtfaxno,mail,branchcode,compcode,userid,hiddenccode);
			//window.location=window.location;
			return false;
			}

		else
		{
		
		 
		if  (opener.document.getElementById('hiddenchk').value=="1")
            {
             
            BranchDetails.chksubmitcontact(contactperson,branchcode,callinsertcontact);

      
           	       
		        return false;
		        }
		    else
		        {
		        return;
		        }

		}
return ;
}
function callsubmitcontact(res)
{
var ds=res.value;
var contactperson=trim(document.getElementById('txtcontactperson').value);
    if(ds.Tables[0].Rows.length>0 && contper != contactperson)
    {
    alert('Contact Person has already been assigned');
    return false;
    }
    else
    {
  //var contactperson=trim(document.getElementById('txtcontactperson').value);
var txtdesignation=trim(document.getElementById('txtdesignation').value);
var txtdob=document.getElementById('txtdob').value;
var txtphoneno=trim(document.getElementById('txtphoneno').value);
var txtext=trim(document.getElementById('txtext').value);
var txtfaxno=trim(document.getElementById('txtfaxno').value);
var mail=trim(document.getElementById('txtemail').value);
var branchcode=document.getElementById('hiddenbranchcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var hiddenccode=document.getElementById('hiddenccode').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var txtdob="";

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdob').value != "")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
txtdob=mm+'/'+dd+'/'+yy;
}
else
{
txtdob=document.getElementById('txtdob').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdob').value!="")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
txtdob=mm+'/'+dd+'/'+yy;
}
else
{
txtdob=document.getElementById('txtdob').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
txtdob=document.getElementById('txtdob').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
txtdob=document.getElementById('txtdob').value;
}
         BranchDetails.submitcontact(contactperson,txtdesignation,txtdob,txtphoneno,txtext,txtfaxno,mail,branchcode,compcode,userid,hiddenccode);
          window.location=window.location;

         
    }
}

function callinsertcontact(res)
{

var ds=res.value;
    if(ds.Tables[0].Rows.length>0)
    {
    alert('Contact Person has already been assigned');
    return false;
    }
    else
    {
  var contactperson=trim(document.getElementById('txtcontactperson').value);
var txtdesignation=trim(document.getElementById('txtdesignation').value);
var txtdob=document.getElementById('txtdob').value;
var txtphoneno=trim(document.getElementById('txtphoneno').value);
var txtext=trim(document.getElementById('txtext').value); 
var txtfaxno=trim(document.getElementById('txtfaxno').value);
var mail=trim(document.getElementById('txtemail').value);
var branchcode=document.getElementById('hiddenbranchcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var hiddenccode=document.getElementById('hiddenccode').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var txtdob="";

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtdob').value != "")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
txtdob=mm+'/'+dd+'/'+yy;
}
else
{
txtdob=document.getElementById('txtdob').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtdob').value!="")
{
var txt=document.getElementById('txtdob').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
txtdob=mm+'/'+dd+'/'+yy;
}
else
{
txtdob=document.getElementById('txtdob').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
txtdob=document.getElementById('txtdob').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
txtdob=document.getElementById('txtdob').value;
}
           
            BranchDetails.insertcontact(contactperson,txtdesignation,txtdob,txtphoneno,txtext,txtfaxno,mail,branchcode,compcode,userid);
	         window.location=window.location;

	        document.getElementById('txtcontactperson').value="";
            document.getElementById('txtdesignation').value="";
            document.getElementById('txtdob').value="";
            document.getElementById('txtphoneno').value="";
            document.getElementById('txtext').value=""; 
            document.getElementById('txtfaxno').value="";
            document.getElementById('txtemail').value="";  
    }
}

function selected(ab)
{
var id=ab;
//saurabh code------------------------------------------------------------------------
    
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       document.getElementById('hiddenccode').value = "";
      document.getElementById('txtcontactperson').value="";
            document.getElementById('txtdesignation').value="";
            document.getElementById('txtdob').value="";
            document.getElementById('txtphoneno').value="";
            document.getElementById('txtext').value=""; 
            document.getElementById('txtfaxno').value="";
            document.getElementById('txtemail').value="";
       if(opener.document.getElementById('hiddensubmod').value==0)
       {
            document.getElementById('Button1').disabled=true;
       }
       else
       {
            document.getElementById('Button1').disabled=false;
       }
       document.getElementById('btndelete').disabled=true;
       document.getElementById(ab).checked=false;
       return;// false;
        
    }
    
    
    
    
    
    //--------------------------------------------------------------------------------------


           var branchcode=document.getElementById('hiddenbranchcode').value;
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
						
var j;
var k=0;

var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
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
	BranchDetails.branchcont12(branchcode,compcode,userid,code11,call_select12);
	return ;
	
	}
	else
	{
		chkclick.checked=false;
       document.getElementById('txtcontactperson').value="";
            document.getElementById('txtdesignation').value="";
            document.getElementById('txtdob').value="";
            document.getElementById('txtphoneno').value="";
            document.getElementById('txtext').value=""; 
            document.getElementById('txtfaxno').value="";
            document.getElementById('txtemail').value="";
          
	return false;
	}
	document.getElementById(ab).checked=true;
	
//	if(k==1)
//	{
//	  if(document.getElementById('hiddenshow').value=="1")
//            {
//		 document.getElementById('btndelete').disabled=false;
//		 }
//	BranchDetails.branchcont12(branchcode,compcode,userid,code10,call_select12);
//	return ;
//	
//	}
//	else
//	{
//	alert("You Can Select One Row At A Time");
//	return false;
//	}
	document.getElementById(ab).checked=true;
	
	
	if(document.getElementById('hiddenshow').value=="2")
	{
	    if(document.getElementById('Button1').disabled==false)
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
/**************************************************************PREVIOUS CODE

var id=ab;
var branchcode=document.getElementById('hiddenbranchcode').value;
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
var j;
var k=0;
var i=document.getElementById("DataGrid1").rows.length -1;
for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	  document.getElementById(str).checked=false;
      document.getElementById(id).checked=true;

     if(id==str)
        {
	    if(document.getElementById(str).checked==true)
	        {
	        k=k+1;
	        code10=document.getElementById(str).value;
	      
	        }
	    }
	}
	document.getElementById(ab).checked=true;

	if(k==1)
	{
	  if(document.getElementById('hiddenshow').value=="1")
            {
		 document.getElementById('btndelete').disabled=false;
		 }
	BranchDetails.branchcont12(branchcode,compcode,userid,code10,call_select12);
	return ;
	
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return false;
	}
	document.getElementById(ab).checked=true;
	
	return ;
}	


function call_select12(response)
{

var ds=response.value;



document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;
	var dateformat=document.getElementById('hiddendateformat').value;
	if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
	{

	var enrolldate=ds.Tables[0].Rows[0].dob;
			var dd=enrolldate.getDate();
			var mm=enrolldate.getMonth() + 1;
			var yyyy=enrolldate.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
	}
	else
	{
	document.getElementById('txtdob').value="";
	}
			
	
	
	document.getElementById('txtcontactperson').value=ds.Tables[0].Rows[0].cont_person;
	document.getElementById('txtdesignation').value=ds.Tables[0].Rows[0].designation;

	if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
	{
	document.getElementById('txtdob').value=enrolldate1;
	}
	else
	{
	document.getElementById('txtdob').value="";
	}
	document.getElementById('txtphoneno').value=ds.Tables[0].Rows[0].phone;
	document.getElementById('txtext').value=ds.Tables[0].Rows[0].extension; 
	document.getElementById('txtfaxno').value=ds.Tables[0].Rows[0].fax;
	document.getElementById('txtemail').value=ds.Tables[0].Rows[0].emailid;
	document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;
return ;

}
*///////////////////////////////////////////////////////////////////////////////////

function call_select12(response)
{
	var ds=response.value;



document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;
	var dateformat=document.getElementById('hiddendateformat').value;
	if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
	{

	var enrolldate=ds.Tables[0].Rows[0].dob;
			var dd=enrolldate.getDate();
			var mm=enrolldate.getMonth() + 1;
			var yyyy=enrolldate.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
	}
	else
	{
	document.getElementById('txtdob').value="";
	}
			
	
	
	document.getElementById('txtcontactperson').value=ds.Tables[0].Rows[0].cont_person;
	document.getElementById('txtdesignation').value=ds.Tables[0].Rows[0].designation;
	contper=trim(document.getElementById('txtcontactperson').value);

	if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
	{
	document.getElementById('txtdob').value=enrolldate1;
	}
	else
	{
	document.getElementById('txtdob').value="";
	}
	document.getElementById('txtphoneno').value=ds.Tables[0].Rows[0].phone;
	if(ds.Tables[0].Rows[0].extension!=null)
	{
	document.getElementById('txtext').value=ds.Tables[0].Rows[0].extension; 
	}
	else
	{
	document.getElementById('txtext').value="";
	}
	if(ds.Tables[0].Rows[0].fax1!=null)
	{
	document.getElementById('txtfaxno').value=ds.Tables[0].Rows[0].fax1;
	}
	else
	{
	document.getElementById('txtfaxno').value="";
	}
	if(ds.Tables[0].Rows[0].emailid!=null)
	{
	document.getElementById('txtemail').value=ds.Tables[0].Rows[0].emailid;
	}
	else
	{
	document.getElementById('txtemail').value="";
	}
	document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;			
				
    if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=true;
	document.getElementById('Button1').disabled=true;
	}
	else if(document.getElementById('hiddenshow').value=="2")
	{
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('Button1').disabled=false;
	}
//	else
//	{
//		document.getElementById('btndelete').disabled=false;
//	    document.getElementById('btnsubmit').disabled=false;
//	}
            //document.getElementById('btnsubmit').disabled=false;
			//document.getElementById('btnDelete').disabled= false;
			//document.getElementById('btnselect').disabled=false;
			//document.getElementById('btnSave').disabled=false;


			return false;
}


function deletecontact()
{

var branchcode=document.getElementById('hiddenbranchcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var hiddenccode=document.getElementById('hiddenccode').value; 

var datagrid=document.getElementById('DataGrid1');

var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
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
BranchDetails.deletecontact(branchcode,compcode,userid,document.getElementById('hiddenccode').value);
	window.location=window.location;
	return false;
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return false;
	}
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

//*********************************************************************************************
//*********************************************************************************************

function addcount_branch(cou)
{
if(typeof(cou)=="object")
{
var country=cou.value;
}
else
{
var country=cou;
}
if(document.getElementById("txtcountry").value!="0")
{
if(hiddentext=="new" || hiddentext== "modify")
{
document.getElementById("txtdist").value="";
 document.getElementById("txtstate").value="";
 document.getElementById('drpzone').value="";
 document.getElementById('drpregion').value="";
}
 BranchMaster.addcou(country,callcount);
return false;
}
else
{
document.getElementById("txtdist").value="";
 document.getElementById("txtstate").value="";
 document.getElementById('drpzone').value="";
 document.getElementById('drpregion').value="";
var pkgitem = document.getElementById("drpcity");
pkgitem.options.length = 1; 
 pkgitem.options[0]=new Option("--Select City--","0");
 
 
 return false;
}

return false;
}
//var cityvar;
function callcount(res)
{

var ds=res.value;

if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

var pkgitem = document.getElementById("drpcity");
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
alert("There is No Matching value Found");
return false;

}

return false;
}



function autoornot()
 {
    document.getElementById('txtbranchname').value=trim(document.getElementById('txtbranchname').value);
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
       
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		  if(document.getElementById('txtbranchname').value!="" )
            {
	          str=document.getElementById('txtbranchname').value;
	         var pubcent=document.getElementById('drppubcenter').value;
	          document.getElementById('txtalias').value=document.getElementById('txtbranchname').value.toUpperCase();
    
			    BranchMaster.chkbranchcode(str,pubcent,fillcall);
			     document.getElementById('txtalias').focus();
    		
			    
		  return false;
		}
	 return false;
		
}



function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("Branch Name has already assigned!! ");
		    document.getElementById('txtbranchname').value="";
		    document.getElementById('txtalias').value="";
		    
	        document.getElementById('txtbranchname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Branch_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtbranchcode').value=str.substr(0,2)+ code;
		                      //   document.getElementById('txtaddress').focus();
    	
		                         }
		                    else
		                         {
		                       
		                       document.getElementById('txtbranchcode').value=str.substr(0,2)+ "0";
		                      document.getElementById('txtbranchcode').value=document.getElementById('txtbranchcode').value.toUpperCase(); 
		                      //  document.getElementById('txtaddress').focus();
    	
		                      //    alert(document.getElementById('txtcurrcode').value);
		                          }
		     }
		       
	return ;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        document.getElementById('txtbranchcode').disabled=false;
     	document.getElementById('txtalias').value=document.getElementById('txtbranchname').value;
     	document.getElementById('txtbranchcode').value=document.getElementById('txtbranchcode').value.toUpperCase(); 
	    auto=document.getElementById('hiddenauto').value;
	    document.getElementById('txtalias').focus();
	    if(document.getElementById('txtbranchname').value!="")
	       BranchMaster.chkbranchcode(document.getElementById('txtbranchname').value,document.getElementById('drppubcenter').value,fillcall1);
         return false;
        }

return false;
}
function chkbranch()
    {
        
	    if(document.getElementById('txtbranchname').value!="")
	       BranchMaster.chkbranchcode(document.getElementById('txtbranchname').value,document.getElementById('drppubcenter').value,fillcall1);
         return false;
    }
function fillcall1(res)
		{
		    var ds=res.value;
		    var newstr;
		    if(ds.Tables[0].Rows.length!=0)
		    {
		        alert("Branch Name has already assigned!! ");
		        document.getElementById('txtbranchname').value="";
		        document.getElementById('txtalias').value="";
		        document.getElementById('txtbranchname').focus();
    	        return false;
		    }
  return false;
}

//*******************************************************************************//


function checkcode()
{
   document.getElementById('txtbranchcode').value
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
 res2=BranchMaster.chkpubcatcode(document.getElementById('txtbranchcode').value);


//		 return false;
		 
}
function fillcall12(res)
{
		var ds=res.value;
		var newstr;
		if(ds==null)
		{ 
		 return false;
		}
	    if(ds.Tables[1].Rows.length!=0 )//&& ds1.Tables[1].Rows.length!=0)
	    {
		    alert("This Branch code has already been assigned !! ");
		     document.getElementById('txtbranchcode').value="";
		     //document.getElementById('txtalias').value="";
		     if(document.getElementById('txtbranchcode').disabled==false)
		        document.getElementById('txtbranchcode').focus();
		      return false;
		 }
		  return false;
}
///////////////sorting of a drop down

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
/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////
function RetCheckdate_brandob(input)
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

	if (!validformat.test())
	{
		if(input.value=="")
		{
		return true;
		}
		alert(" Please Fill The Date In "+dateformat+" Format");
		document.getElementById('txtdob').value="";
		document.getElementById('txtdob').focus();
		return false;
	}
	var saur=document.getElementById('txtdob').value;
	var saa=new Date(saur);
	var saaa=new Date();
	if(saaa<=saa)
	{
	    alert("Date of Birth Sholud Be Less Than Today's date ");
	    document.getElementById('txtdob').value="";
	    document.getElementById('txtdob').focus();
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

/////////////////////////////////////////////////////////////////////////////
//function RetCheckdate_brandob(input)
//{
//	var dateformat=document.getElementById('hiddendateformat').value;
//	if(dateformat=="mm/dd/yyyy")
//	{
//		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
//	 
//	}
//	if(dateformat=="yyyy/mm/dd")
//	 
//	{
//		var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
//	}
//	if(dateformat=="dd/mm/yyyy")
//	{
//		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
//	}

//	if (!validformat.test())
//	{
//		if(input.value=="")
//		{
//		return true;
//		}
//		alert(" Please Fill The Date In "+dateformat+" Format");
//		document.getElementById('txtdob').value="";
//		return false;
//	}
//}








function F2fillempcode(event) {

        if (event.keyCode == 113) {
            if (document.activeElement.id == "txtemcode") {
                //$('txtagency').value="";
                var compcode = document.getElementById('hiddencompcode').value;
                var empname = document.getElementById('txtemcode').value;
                document.getElementById("divempcode").style.display = "block";
                document.getElementById("lstempcode").style.display = "block";
                document.getElementById('divempcode').style.top = 278 + "px";
                document.getElementById('divempcode').style.left = 580 + "px";
                document.getElementById('lstempcode').focus();
                var ds = Execondetail.empcodebind(compcode, empname);
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
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].NAME+'(' + ds_AccName.Tables[0].Rows[i].EMP_CODE + ')'+'/'+ds_AccName.Tables[0].Rows[i].FATHER_NAME+'/'+ds_AccName.Tables[0].Rows[i].BRANCH_NAME, ds_AccName.Tables[0].Rows[i].EMP_CODE);
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
                         abc=abc.split("/");
                        abc=abc[0];
                        
                        document.getElementById('txtemcode').value = abc;

                        document.getElementById('hdempcode').value = page;
                        document.getElementById('txtexename').value=  ds_AccName.Tables[0].Rows[k-1].NAME
                       document.getElementById('txtaddress').value=  ds_AccName.Tables[0].Rows[k-1].ADDR1+ds_AccName.Tables[0].Rows[k-1].ADDR2+ds_AccName.Tables[0].Rows[k-1].ADDR3;
                        document.getElementById('txtpin').value=  ds_AccName.Tables[0].Rows[k-1].PIN
                         document.getElementById('txtemail').value=  ds_AccName.Tables[0].Rows[k-1].EMAIL
                          document.getElementById('txtmobile').value=  ds_AccName.Tables[0].Rows[k-1].MOBILE
                           document.getElementById('drpbranch1').value=  ds_AccName.Tables[0].Rows[k-1].BRAN_CODE
                        
                        
                        //                    document.getElementById('hdnretainername').value =abc;

                        document.getElementById("divempcode").style.display = "none";
                        document.getElementById("lstempcode").style.display = "none";
                        document.getElementById('txtemcode').focus();
                        return false;

                    }

                }


            }

        }
        else if (event.keyCode == 27) {

        document.getElementById("divempcode").style.display = "none";
        document.getElementById("lstempcode").style.display = "none";
            document.getElementById('txtemcode').focus();
            return false;
        }
//        return false;
    }
