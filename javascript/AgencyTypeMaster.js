var d="0";
var z=0;
var k = 0;
//-----------------
//this flag is for permission
var flag="";
var hiddentext;
var auto="";
var hiddentext1="";
var dsexecute;
var gbatmcode;
var	gbatmname;
var	gbatmalias;


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

 /*function loadPages()
    {
    	
     var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","button.aspx", false );
		xml.Send();
		 var rp=xml.responseText;
		alert(rp);
		//document.getElementById('div1').innerHTML=rp;
    }*/
function atmNewclick()	
{	
			
			 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtagencycode').disabled=true;
    	          }
		         else
		           {
		           document.getElementById('txtagencycode').disabled=false;
    	           }
				
			
				document.getElementById('txtagencycode').value="";
				document.getElementById('txtagencyname').value="";	
				document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
				document.getElementById('txtalias').value="";
				document.getElementById('txtefffrom').value="";
				document.getElementById('txtefftill').value="";
				document.getElementById('txtcommrate').value="";
				document.getElementById('drpcommdetail').value="0";
				document.getElementById('txtcreditdays').value="";
				document.getElementById('drpadcat').value="0";
				document.getElementById('drpcommisionreq').value="0";
					document.getElementById('drpmrvno').value="0";
					document.getElementById('txttargettable').value="";
					document.getElementById('drpmonthenddate').value="0";
					
				
				//document.getElementById('txtagencycode').disabled=false;			
				document.getElementById('txtagencyname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('txtefffrom').disabled=false;
				document.getElementById('txtefftill').disabled=false;
				document.getElementById('txtcommrate').disabled=false;
				document.getElementById('drpcommdetail').disabled=false;
				document.getElementById('txtcreditdays').disabled=false;
				document.getElementById('drpadcat').disabled=false;
				document.getElementById('drpcommisionreq').disabled=false;
				document.getElementById('drpmrvno').disabled=false;
				document.getElementById('txttargettable').disabled=false;
				document.getElementById('drpmonthenddate').disabled=false;
				
				 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtagencyname').focus();
    	          }
		         else
		           {
		           if(document.getElementById('txtagencycode').disabled==false)
		                document.getElementById('txtagencycode').focus();
    	           }
				
				
				d="0";
				
				/*document.getElementById('btnNew').disabled=true;
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
				document.getElementById('btnExit').disabled=false;*/
				
				chkstatus(FlagStatus);
				
				hiddentext="new";	
				
				
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
	setButtonImages();
				return false;
}



function atmQueryclick()		
{
			hiddentext="query";
			z=0;
				chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
			hiddentext="query";

		    /*	document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;*/
			
			document.getElementById('txtagencycode').value="";
			document.getElementById('txtagencyname').value="";
				document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
			document.getElementById('txtalias').value="";
			document.getElementById('txtefffrom').value="";
			document.getElementById('txtefftill').value="";
			document.getElementById('txtcommrate').value="";
			document.getElementById('drpcommdetail').value="0";
			document.getElementById('txtcreditdays').value="";
			document.getElementById('drpadcat').value="0";
			document.getElementById('drpcommisionreq').value="0";
											
			document.getElementById('txtagencycode').disabled=false;
			document.getElementById('txtagencyname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('txtefffrom').disabled=true;
			document.getElementById('txtefftill').disabled=true;
			document.getElementById('txtcommrate').disabled=true;
			document.getElementById('drpcommdetail').disabled=true;
			document.getElementById('txtcreditdays').disabled=true;
				document.getElementById('drpadcat').disabled=true;
				document.getElementById('drpcommisionreq').disabled=true;
		  
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
			
			setButtonImages();
			return false;
}

function atmExecuteclick()
{
			var companycode=document.getElementById('hiddencomcode').value;
			var code=document.getElementById('txtagencycode').value;
			
			var name=document.getElementById('txtagencyname').value;
			var alias=document.getElementById('txtalias').value;
			var UserId = document.getElementById('hiddenuserid').value;
			k = '1';
			
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
AgencyTypeMaster.atmexecute(companycode,code,name,alias,UserId,checkcall);
			
			updateStatus();
			
								
			document.getElementById('txtagencycode').disabled=true;
			document.getElementById('txtagencyname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtefffrom').disabled=true;
			document.getElementById('txtefftill').disabled=true;
			document.getElementById('txtcommrate').disabled=true;
			document.getElementById('drpcommdetail').disabled=true;
			document.getElementById('txtcreditdays').disabled=true;
			document.getElementById('drpadcat').disabled=true;
			document.getElementById('drpcommisionreq').disabled=true;
			document.getElementById('drpmrvno').disabled=true;
		document.getElementById('drpmonthenddate').disabled=true;
						
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnlast').disabled=false;	
			
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnlast').disabled=false;			
			document.getElementById('btnExit').disabled=false;*/
			
			
			
			return false;			
}

function checkcall(response)
{
		ds=response.value;
		if (ds.Tables[0].Rows.length <= 0)
		{
			alert("Your search can't produce any result");
			atmCancelclick('AgencyTypeMaster');
			return false;
		}
		else
		{
		var companycode=document.getElementById('hiddencomcode').value;
		var code=document.getElementById('txtagencycode').value;
		gbatmcode=code;
		var name=document.getElementById('txtagencyname').value;
		gbatmname=name;
		var alias=document.getElementById('txtalias').value;
		gbatmalias=alias;	
		var UserId=document.getElementById('hiddenuserid').value;	
					
		AgencyTypeMaster.atmexecute1(companycode,code,name,alias,UserId,checkcall1);							
		return false;
		}
}
						
function checkcall1(response)
{

		dsexecute=response.value;
		document.getElementById('txtagencycode').value=dsexecute.Tables[0].Rows[0].Agency_Type_Code;
		document.getElementById('txtagencyname').value=dsexecute.Tables[0].Rows[0].Agency_Type_Name;
			document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_Type_Alias;
		document.getElementById('drpadcat').value=dsexecute.Tables[0].Rows[0].Ad_category;
		document.getElementById('drpcommisionreq').value=dsexecute.Tables[0].Rows[0].COMM_REQ;
		document.getElementById('hiddenuniqueid').value=dsexecute.Tables[0].Rows[0].Ad_typeuniqueid;
		document.getElementById('drpmrvno').value=dsexecute.Tables[0].Rows[0].MRVREF;
		document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[0].PAM_TARGET_TABLENAME;
			document.getElementById('drpmonthenddate').value=dsexecute.Tables[0].Rows[0].MONTH_END_BILLDT_REQ;
		
		//code for date
		
		var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(dsexecute.Tables[0].Rows[0].Effective_From != null && dsexecute.Tables[0].Rows[0].Effective_From != "")
			{
	    var validate_fromdate = dsexecute.Tables[0].Rows[0].Effective_From;
	    var dd = "";
	    var mm = "";
	    var yyyy = "";
	    if (document.getElementById('hdnconntype').value != "mysql") {
	         dd = validate_fromdate.getDate();
	         mm = validate_fromdate.getMonth() + 1;
	         yyyy = validate_fromdate.getFullYear();
	    }
	    else {
            
	         dd = validate_fromdate.split('/')[0];
	         mm = validate_fromdate.split('/')[1];
	         yyyy = validate_fromdate.split('/')[2];
	    }
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefffrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefffrom').value="";
			}
			
			if(dsexecute.Tables[0].Rows[0].Effective_Till != null && dsexecute.Tables[0].Rows[0].Effective_Till != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[0].Effective_Till;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefftill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefftill').value="";
			}
		
				document.getElementById('txtcommrate').value=dsexecute.Tables[0].Rows[0].Comm_Rate;
				document.getElementById('drpcommdetail').value=dsexecute.Tables[0].Rows[0].Comm_Apply;
				
				document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[0].Creditdays;
				
				
//				document.getElementById('btnnext').disabled=false;			
//				document.getElementById('btnlast').disabled=false;
		
		
		
		if(dsexecute.Tables[0].Rows.length==1)
		{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;
		
		}
		
		if(z==0)
		{
	        document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			
		}
		
		if(z==dsexecute.Tables[0].Rows.length-1)
		{
	    	document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;
	
		
		}
		setButtonImages();

		d = "5";
		
		return false;
}

function atmCancelclick(formname)
{
				/*document.getElementById('btnNew').disabled=false;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExit').disabled=false;*/
    d = "0";
				document.getElementById('txtagencycode').value="";
				document.getElementById('txtagencyname').value="";
					document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
				document.getElementById('txtalias').value="";
				document.getElementById('txtcreditdays').value="";
			
				
				document.getElementById('txtefffrom').value="";
			document.getElementById('txtefftill').value="";
			document.getElementById('txtcommrate').value="";
			document.getElementById('drpcommdetail').value="0";
			document.getElementById('drpadcat').value="0";
			document.getElementById('drpcommisionreq').value="0";
			document.getElementById('drpmrvno').value="0";
				document.getElementById('txttargettable').value="";
				document.getElementById('drpmonthenddate').value="0";
				
				//getPermission(formname);
				//call the xml button page
					chkstatus(FlagStatus);
		 givebuttonpermission(formname);
		 if(FlagStatus!=2 && FlagStatus!=4 && FlagStatus!=6)
		 document.getElementById('btnNew').focus();
		//alert(rp);
		
		////////////////////////
				
				document.getElementById('txtagencycode').disabled=true;
				document.getElementById('txtagencyname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtefffrom').disabled=true;
			document.getElementById('txtefftill').disabled=true;
			document.getElementById('txtcommrate').disabled=true;
			document.getElementById('drpcommdetail').disabled=true;
			document.getElementById('txtcreditdays').disabled=true;
			document.getElementById('drpadcat').disabled=true;
			document.getElementById('drpcommisionreq').disabled=true;
			document.getElementById('txttargettable').disabled=true;
			document.getElementById('drpmonthenddate').disabled = true;
			document.getElementById('drpmrvno').disabled = true;
			
		
			  var dl="";
       var agencytypecode="";
        if(browser!="Microsoft Internet Explorer" && browser!="Netscape")
        {
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
             httpRequest.onreadystatechange = function() {alertContents_chk(httpRequest) };
        
          
            httpRequest.open('GET', "agencytypenull.aspx?"+"agencytypecode="+agencytypecode, false);
            httpRequest.send('');
            dl=httpRequest.responseText;
          
            

        }
        else if(browser=="Microsoft Internet Explorer")
        {
         
           var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","agencytypenull.aspx?"+"agencytypecode="+agencytypecode, false );
	        xml.Send();
	        dl=xml.responseText;
         
          
        }
		
			
			setButtonImages();
				return false;
}


function atmSaveclick() {

var comp_code = document.getElementById('hiddencomcode').value;
    var agencytypecode = document.getElementById('txtagencycode').value;

//  //  var a = AgencyTypeMaster.chkslab11(comp_code, agencytypecode);
//    if (a == "true") {
//        alert("not save")
//        return false;
//    }
   
    var comm_req = document.getElementById('drpcommisionreq').value;

//    if (comm_req == "Y") {

//        if (a.value.Tables[0].Rows[0].No == null || a.value.Tables[0].Rows[0].No == "");  
//        {

//            alert("aaaa");
//            return false;
//        }
//    }
//    else {
//       
//      
//    }
    
    
			document.getElementById('txtagencyname').value=trim(document.getElementById('txtagencyname').value);
				//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
			document.getElementById('txtagencycode').value=trim(document.getElementById('txtagencycode').value);
			document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
			
			//if(document.getElementById('hiddenauto').value!=1)
                //{
			if(document.getElementById('txtagencycode').value=="")
			{
				alert("Please Fill Agency Code");
				if(document.getElementById('txtagencycode').disabled==false)
				    document.getElementById('txtagencycode').focus();
				return false;
			}
			//return false;
			//}
			else if(document.getElementById('txtagencyname').value=="")
			{
				alert("Please Fill Agency Type Name");
				document.getElementById('txtagencyname').focus();
				return false;
			}
			
			else if(document.getElementById('txtalias').value=="")
			{
				alert("Please Fill Agency Alias");
				document.getElementById('txtalias').focus();
				return false;
			}
			else if(document.getElementById('txtcommrate').value=="")
			{
				alert("Please Fill Commission Rate %");
				document.getElementById('txtcommrate').focus();
				return false;
			}
			else if(document.getElementById('txtcreditdays').value=="")
			{
					
				alert("Please Fill Credit Days ");
				document.getElementById('txtcreditdays').focus();
				return false;
			}
			
			   else if(document.getElementById('drpcommdetail').value=="0")
			{
				alert("Please Select Commission Apply On");
				document.getElementById('drpcommdetail').focus();
				return false;
			}
			 else if(document.getElementById('txtefffrom').value=="")
			{
				alert("Please Enter Effective From Date");
				document.getElementById('txtefffrom').focus();
				return false;
			}
			 else if(document.getElementById('txtefftill').value=="")
			{
				alert("Please Enter Effective Till Date");
				document.getElementById('txtefftill').focus();
				return false;
			}
			else if(document.getElementById('txtefffrom').value!=""|| document.getElementById('txtefftill').value!="")
			{
			
			var fromdate=document.getElementById('txtefffrom').value;
		    var todate=document.getElementById('txtefftill').value;
		    var dateformat=document.getElementById('hiddendateformat').value;
		if(dateformat=="dd/mm/yyyy")
        {
        var txt=fromdate;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        fromdate=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="mm/dd/yyyy")
        {
        fromdate=fromdate;
        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=fromdate;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
       fromdate=mm+'/'+dd+'/'+yy;
        }

if(dateformat=="dd/mm/yyyy")
        {
        var txt=todate;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        todate=mm+'/'+dd+'/'+yy;

        }
        if(dateformat=="mm/dd/yyyy")
        {
        todate=todate;
        }
        if(dateformat=="yyyy/mm/dd")
        {
        var txt=todate;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
       todate=mm+'/'+dd+'/'+yy;
        }
		    var fdate=new Date(fromdate);
		    var tdate=new Date(todate);
		      if(fdate > tdate)
		     {
		       alert("Effective From Date Should be Less Then Effective Till Date");
		
		         document.getElementById('txtefffrom').focus();
		        return false;
		
		      }
			}
			
			
			
			//chklimit();
			
			
				var companycode=document.getElementById('hiddencomcode').value;
				var agcode=document.getElementById('txtagencycode').value;
				var name=document.getElementById('txtagencyname').value;
				var alias=document.getElementById('txtalias').value;
				var UserId=document.getElementById('hiddenuserid').value;	
				var code=document.getElementById('drpadcat').value;
				var adtypname=document.getElementById('txtagencyname').value
				var mrvno=document.getElementById('drpmrvno').value
				var PAM_TARGET_TABLENAME=document.getElementById('txttargettable').value
				var monthdate=document.getElementById('drpmonthenddate').value
				
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

			
				if(d!="1" && d!=null)
				{
					AgencyTypeMaster.chkatmcode(companycode,UserId,agcode,name,call_saveclick);
				}
				else
				{
				
				//effective from and effective till code
				
				var dateformat=document.getElementById('hiddendateformat').value;
				var txtefffrom="";
		        var txtefftill="";		
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
 txtefffrom=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
 txtefffrom=document.getElementById('txtefffrom').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
 txtefffrom=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
txtefffrom=document.getElementById('txtefffrom').value;
}

if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
txtefftill=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
 txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
txtefftill=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
 txtefftill=document.getElementById('txtefftill').value;
}

/////////////////////////////////////////////////////

                var commrate=document.getElementById('txtcommrate').value;
				var commdetail=document.getElementById('drpcommdetail').value;
				var creditdays=document.getElementById('txtcreditdays').value;
				var adcat=document.getElementById('drpadcat').value;
				
				var mrvno=document.getElementById('drpmrvno').value
				var PAM_TARGET_TABLENAME=document.getElementById('txttargettable').value
					var monthdate=document.getElementById('drpmonthenddate').value
				
				
				//var uniqueid=document.getElementById('txtagencycode').value + adcat;
				var uniqueid=document.getElementById('hiddenuniqueid').value;
				if(name!=document.getElementById('hiddenagtypename').value)
				{
				    var res=AgencyTypeMaster.chkatmcode(companycode,UserId,code,name);
				    if(res.value.Tables[1].Rows.length>0)
				    {
				        alert("This Agency Type Name Is Already Exist, Try Another Name !!!!");
				        document.getElementById('txtagencyname').focus();
				        return false;
				    }
				}
				
				
				var ip2=document.getElementById('ip1').value;
				var comm_req = document.getElementById('drpcommisionreq').value;

				var comp_code = document.getElementById('hiddencomcode').value;
				var agencytypecode = document.getElementById('txtagencycode').value;

				var a = AgencyTypeMaster.chkslab11(comp_code, agencytypecode);


				var comm_req = document.getElementById('drpcommisionreq').value;

				if (comm_req == "Y") {

				    if (a.value.Tables[0].Rows[0].NO == null || a.value.Tables[0].Rows[0].NO == "") {

				        alert("Select Agency Type Slab ");
				        return false;
				    }
				}
			    
				/*if (document.getElementById('hdnconntype').value == "mysql")
				{
				    var dd = txtefffrom.split('/')[1];
				    var mm = txtefffrom.split('/')[0];
				    var yy = txtefffrom.split('/')[2];

				    txtefffrom = yy + "/" + mm + "/" + dd;

				    var dd1 = txtefftill.split('/')[1];
				    var mm1 = txtefftill.split('/')[0];
				    var yy1 = txtefftill.split('/')[2];

				    txtefftill = yy1 + "/" + mm1 + "/" + dd1;
				}*/
				AgencyTypeMaster.atmmodify(companycode,code,name,alias,UserId,txtefffrom,txtefftill,commrate,commdetail,creditdays,adcat,uniqueid,ip2,mrvno,PAM_TARGET_TABLENAME,monthdate,comm_req); 
			   
			    dsexecute.Tables[0].Rows[z].Agency_Type_Code=document.getElementById('txtagencycode').value;
			    document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;
				dsexecute.Tables[0].Rows[z].Agency_Type_Name=document.getElementById('txtagencyname').value;
				dsexecute.Tables[0].Rows[z].Agency_Type_Alias=document.getElementById('txtalias').value;
			    dsexecute.Tables[0].Rows[z].Effective_From=fdate;
			    dsexecute.Tables[0].Rows[z].Effective_Till=tdate;
			    dsexecute.Tables[0].Rows[z].Comm_Rate=document.getElementById('txtcommrate').value;
				dsexecute.Tables[0].Rows[z].Comm_Apply=document.getElementById('drpcommdetail').value;
			    dsexecute.Tables[0].Rows[z].Creditdays=document.getElementById('txtcreditdays').value;
			    dsexecute.Tables[0].Rows[z].Ad_category=document.getElementById('drpadcat').value;
			    dsexecute.Tables[0].Rows[z].COMM_REQ=document.getElementById('drpcommisionreq').value;
			     dsexecute.Tables[0].Rows[z].PAM_TARGET_TABLENAME=document.getElementById('txttargettable').value;
			     dsexecute.Tables[0].Rows[z].MONTH_END_BILLDT_REQ=document.getElementById('drpmonthenddate').value;
			     // alert(xmlObj.childNodes(0).childNodes(1).text); 
	if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
				//alert("Data Modified Successfully");
				
					updateStatus();
					
			if(z==0)
			{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;

			}
			if(z==dsexecute.Tables[0].Rows.length-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
		
			}
					document.getElementById('txtagencycode').disabled=true;
					document.getElementById('txtagencyname').disabled=true;
					document.getElementById('txtalias').disabled=true;
					document.getElementById('txtefffrom').disabled=true;
					document.getElementById('txtefftill').disabled=true;
					document.getElementById('txtcommrate').disabled=true;
					document.getElementById('drpcommdetail').disabled=true;
					document.getElementById('txtcreditdays').disabled=true;
					document.getElementById('drpadcat').disabled=true;
					document.getElementById('drpcommisionreq').disabled=true;
					document.getElementById('txttargettable').disabled=true;
					document.getElementById('drpmonthenddate').disabled = true;
					document.getElementById('drpmrvno').disabled = true;
					
					/*document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;		
											
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;*/
					
					d="0";
				}
			//}
			setButtonImages();
			return false;
}

function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Agency Type Code Is Already Exist, Try Another Code !!!!");
				return false;
			} 
			else if(ds.Tables[1].Rows.length > 0)
			{
				alert("This Agency Type Name Is Already Exist, Try Another Name !!!!");
				return false;
			} 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var code=document.getElementById('txtagencycode').value;
				var name=document.getElementById('txtagencyname').value;
				var alias=document.getElementById('txtalias').value;
				var UserId=document.getElementById('hiddenuserid').value;	
				var adcat=document.getElementById('drpadcat').value;	
				var mrvno=document.getElementById('drpmrvno').value;
				var PAM_TARGET_TABLENAME=document.getElementById('txttargettable').value;
					var monthdate=document.getElementById('drpmonthenddate').value
				
				var codeunique=code + adcat;
			var txtefffrom="";	
			var txtefftill="";
				//effective from and effective till code
				
var dateformat=document.getElementById('hiddendateformat').value;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
 txtefffrom=mm+'/'+dd+'/'+yy;

}
if(dateformat=="mm/dd/yyyy")
{
 txtefffrom=document.getElementById('txtefffrom').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefffrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
 txtefffrom=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
txtefffrom=document.getElementById('txtefffrom').value;
}


if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
 txtefftill=mm+'/'+dd+'/'+yy;
}
if(dateformat=="mm/dd/yyyy")
{
 txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
 txtefftill=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{


txtefftill=document.getElementById('txtefftill').value;
}
var agencytypecode=document.getElementById('txtagencycode').value;

/////////////////////////////////////////

 if(browser!="Microsoft Internet Explorer")
        {
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
             //httpRequest.onreadystatechange = function() {alertContents_save(httpRequest) };


             httpRequest.open('GET', "agency_type_save.aspx?"+"agencytypecode="+agencytypecode, false);
            httpRequest.send('');
            dl = httpRequest.responseText;


         
		     
          
            

        }
        else if(browser=="Microsoft Internet Explorer")
        {
         
          	 var xml = new ActiveXObject("Microsoft.XMLHTTP");
          	 xml.Open("GET", "agency_type_save.aspx?"+"agencytypecode="+agencytypecode, false); 
		     xml.Send();
		     dl = xml.responseText;


		
		     
          
        }

        var comp_code = document.getElementById('hiddencomcode').value;
        var agencytypecode = document.getElementById('txtagencycode').value;

        var a = AgencyTypeMaster.chkslab11(comp_code, agencytypecode);


        var comm_req = document.getElementById('drpcommisionreq').value;

            if (comm_req == "Y") {

                if (a.value.Tables[0].Rows[0].NO == null || a.value.Tables[0].Rows[0].NO == "")  
               {

                   alert("Select Agency Type Slab ");
                   return false;
                }
            }
            
///////////////////////////////////










/////////////////////////////////////////////////////

                var commrate=document.getElementById('txtcommrate').value;
				var commdetail=document.getElementById('drpcommdetail').value;
                var creditdays=document.getElementById('txtcreditdays').value;
                //var dateformat=document.getElementById('hiddendateformat').value;
				var ip2=document.getElementById('ip1').value;
				var comm_req = document.getElementById('drpcommisionreq').value;

				
			/*	if (document.getElementById('hdnconntype').value == "mysql") {
				    var dd = txtefffrom.split('/')[1];
				    var mm = txtefffrom.split('/')[0];
				    var yy = txtefffrom.split('/')[2];

				    txtefffrom = yy + "/" + mm + "/" + dd;

				    var dd1 = txtefftill.split('/')[1];
				    var mm1 = txtefftill.split('/')[0];
				    var yy1 = txtefftill.split('/')[2];

				    txtefftill = yy1 + "/" + mm1 + "/" + dd1;
				}*/
				    AgencyTypeMaster.atmsave(companycode, code, name, alias, UserId, txtefffrom, txtefftill, commrate, commdetail, creditdays, adcat, codeunique, ip2, mrvno, PAM_TARGET_TABLENAME, monthdate, comm_req);
				
			   if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}

				document.getElementById('txtagencycode').value="";
				document.getElementById('txtagencyname').value="";
					//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
				document.getElementById('txtalias').value="";
				
				document.getElementById('txtefffrom').value="";
				document.getElementById('txtefftill').value="";
				document.getElementById('txtcommrate').value="";
				document.getElementById('drpcommdetail').value="0";
				document.getElementById('txtcreditdays').value="";
				document.getElementById('drpadcat').value="0"
				document.getElementById('drpcommisionreq').value="0"
				document.getElementById('drpmrvno').value="0"
				document.getElementById('txttargettable').value="";
				document.getElementById('drpmonthenddate').value="0"
						
				document.getElementById('txtagencycode').disabled=true;
				document.getElementById('txtagencyname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtcreditdays').disabled=true;
						document.getElementById('drpadcat').disabled=true;	
						
document.getElementById('drpcommisionreq').disabled=true;	
				document.getElementById('drpmrvno').disabled=true;	
						document.getElementById('txttargettable').disabled=true;
						document.getElementById('drpmonthenddate').disabled = true;
						
						
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
			}
atmCancelclick('AgencyTypeMaster');
			return false;
}


function atmModifyclick()
{
				document.getElementById('txtagencycode').disabled=true;
				document.getElementById('txtagencyname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('txtefffrom').disabled=false;
			   document.getElementById('txtefftill').disabled=false;
			   document.getElementById('txtcommrate').disabled=false;
			   document.getElementById('drpcommdetail').disabled=false;
			   document.getElementById('txtcreditdays').disabled=false;
			     document.getElementById('txttargettable').disabled=false;
			     
			   document.getElementById('drpadcat').disabled=false;
			   
document.getElementById('drpcommisionreq').disabled=false;
				  document.getElementById('drpmrvno').disabled=false;
				  document.getElementById('txttargettable').disabled=false;
						  document.getElementById('drpmonthenddate').disabled=false;
						  
						  
						  
				chkstatus(FlagStatus);
				
				hiddentext="modify";
				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
				
			
				d="1";
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
		    document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;*/
				
				setButtonImages();
				return false;
}

/*function atmfirstclick()
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
AgencyTypeMaster.atmfpnl(firstcall);
					
				document.getElementById('txtagencycode').disabled=true;
				document.getElementById('txtagencyname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtefffrom').disabled=true;
			    document.getElementById('txtefftill').disabled=true;
			    document.getElementById('txtcommrate').disabled=true;
			    document.getElementById('drpcommdetail').disabled=true;
				document.getElementById('txtcreditdays').disabled=true;
				document.getElementById('drpadcat').disabled=true;
				
				
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;	
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;	
		
				return false;
}*/

function atmfirstclick()
{
z=0;
				//ds=response.value;
				document.getElementById('txtagencycode').value=dsexecute.Tables[0].Rows[0].Agency_Type_Code;
				document.getElementById('txtagencyname').value=dsexecute.Tables[0].Rows[0].Agency_Type_Name;
					document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_Type_Alias;
				document.getElementById('hiddenuniqueid').value=dsexecute.Tables[0].Rows[0].Ad_typeuniqueid;
				document.getElementById('drpmrvno').value=dsexecute.Tables[0].Rows[0].MRVREF;
					document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[0].PAM_TARGET_TABLENAME;
						document.getElementById('drpmonthenddate').value=dsexecute.Tables[0].Rows[0].MONTH_END_BILLDT_REQ;
					
				//code for date
		
		var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(dsexecute.Tables[0].Rows[0].Effective_From != null && dsexecute.Tables[0].Rows[0].Effective_From != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[0].Effective_From;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefffrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefffrom').value="";
			}
			
			
			if(dsexecute.Tables[0].Rows[0].Effective_Till != null && dsexecute.Tables[0].Rows[0].Effective_Till != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[0].Effective_Till;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefftill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefftill').value="";
			}
		
				document.getElementById('txtcommrate').value=dsexecute.Tables[0].Rows[0].Comm_Rate;
				document.getElementById('drpcommdetail').value=dsexecute.Tables[0].Rows[0].Comm_Apply;
				
				document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[0].Creditdays;
				document.getElementById('drpadcat').value=dsexecute.Tables[0].Rows[0].Ad_category;
				document.getElementById('drpcommisionreq').value=dsexecute.Tables[0].Rows[0].COMM_REQ;
				
				updateStatus();
                document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnprevious').disabled=true;
				setButtonImages();
				return false;
}

/*function atmpreviousclick()
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
AgencyTypeMaster.atmfpnl(previouscall);
				
				document.getElementById('txtagencycode').disabled=true;
				document.getElementById('txtagencyname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtcreditdays').disabled=true;
				
				return false;
}*/

function atmpreviousclick()
{
		z--;
		//ds=response.value;
		var x=dsexecute.Tables[0].Rows.length;
	
		
		if(z>x)
		{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnlast').disabled=true;
				return false;
		}
		if(z!=-1 && z>=0)
		{
		if(dsexecute.Tables[0].Rows.length != z)
		{
				document.getElementById('txtagencycode').value=dsexecute.Tables[0].Rows[z].Agency_Type_Code;
				document.getElementById('txtagencyname').value=dsexecute.Tables[0].Rows[z].Agency_Type_Name;
					document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_Type_Alias;
				document.getElementById('hiddenuniqueid').value=dsexecute.Tables[0].Rows[z].Ad_typeuniqueid;
				
				document.getElementById('drpmrvno').value=dsexecute.Tables[0].Rows[z].MRVREF;
				document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[z].PAM_TARGET_TABLENAME;
				document.getElementById('drpmonthenddate').value=dsexecute.Tables[0].Rows[z].MONTH_END_BILLDT_REQ;
				
				//code for date
		
		var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(dsexecute.Tables[0].Rows[z].Effective_From != null && dsexecute.Tables[0].Rows[z].Effective_From != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[z].Effective_From;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefffrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefffrom').value="";
			}
			
			if(dsexecute.Tables[0].Rows[z].Effective_Till != null && dsexecute.Tables[0].Rows[z].Effective_Till != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[z].Effective_Till;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefftill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefftill').value="";
			}
		
				document.getElementById('txtcommrate').value=dsexecute.Tables[0].Rows[z].Comm_Rate;
				document.getElementById('drpcommdetail').value=dsexecute.Tables[0].Rows[z].Comm_Apply;
				
				document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[z].Creditdays;
				document.getElementById('drpadcat').value=dsexecute.Tables[0].Rows[z].Ad_category;
				document.getElementById('drpcommisionreq').value=dsexecute.Tables[0].Rows[z].COMM_REQ;
				
				
				
				updateStatus();				
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnlast').disabled=false;
					
		}
		else
		{
				document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
				return false;
		}
		}
		else
		{
				document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
				return false;
		}	
		
		
		if (z<=0)
		{
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnlast').disabled=false;	
				setButtonImages();
				return false;		
		}
		setButtonImages();
		return false;
		
}

/*function atmnextclick()
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
AgencyTypeMaster.atmfpnl(nextcall);
				
				document.getElementById('txtagencycode').disabled=true;
				document.getElementById('txtagencyname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtefffrom').disabled=true;
			document.getElementById('txtefftill').disabled=true;
			document.getElementById('txtcommrate').disabled=true;
			document.getElementById('drpcommdetail').disabled=true;
			document.getElementById('txtcreditdays').disabled=true;
				
				return false;
}*/

function atmnextclick()
{		
		z++;
		//ds=response.value;
		var x=dsexecute.Tables[0].Rows.length;
		if(z <= x && z >= 0)
		{
			if(dsexecute.Tables[0].Rows.length != z && z !=-1)
			{
				document.getElementById('txtagencycode').value=dsexecute.Tables[0].Rows[z].Agency_Type_Code;
				document.getElementById('txtagencyname').value=dsexecute.Tables[0].Rows[z].Agency_Type_Name;
					document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_Type_Alias;
				document.getElementById('hiddenuniqueid').value=dsexecute.Tables[0].Rows[z].Ad_typeuniqueid;
				document.getElementById('drpmrvno').value=dsexecute.Tables[0].Rows[z].MRVREF;
				document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[z].PAM_TARGET_TABLENAME;
				document.getElementById('drpmonthenddate').value=dsexecute.Tables[0].Rows[z].MONTH_END_BILLDT_REQ;
				
				
				//code for date
		
		var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(dsexecute.Tables[0].Rows[z].Effective_From != null && dsexecute.Tables[0].Rows[z].Effective_From != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[z].Effective_From;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefffrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefffrom').value="";
			}
			
			if(dsexecute.Tables[0].Rows[z].Effective_Till != null && dsexecute.Tables[0].Rows[z].Effective_Till != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[z].Effective_Till;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefftill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefftill').value="";
			}
		
				document.getElementById('txtcommrate').value=dsexecute.Tables[0].Rows[z].Comm_Rate;
				document.getElementById('drpcommdetail').value=dsexecute.Tables[0].Rows[z].Comm_Apply;
				
				document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[z].Creditdays;
				document.getElementById('drpadcat').value=dsexecute.Tables[0].Rows[z].Ad_category;
				document.getElementById('drpcommisionreq').value=dsexecute.Tables[0].Rows[z].COMM_REQ;
				
				
				
				updateStatus();
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnlast').disabled=false;
				
			} 
			else
			{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnlast').disabled=true;
				return false;
			}
		}
			else
			{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnlast').disabled=true;
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

/*function atmlastclick()
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
AgencyTypeMaster.atmfpnl(lastcall);
				
				document.getElementById('txtagencycode').disabled=true;
				document.getElementById('txtagencyname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('txtefffrom').disabled=true;
			document.getElementById('txtefftill').disabled=true;
			document.getElementById('txtcommrate').disabled=true;
			document.getElementById('drpcommdetail').disabled=true;
			document.getElementById('txtcreditdays').disabled=true;
				
				return false;
}*/

function atmlastclick()
{
		 //ds= response.value;
     	 var x=dsexecute.Tables[0].Rows.length;
		 z=x-1;
		 x=x-1;

		document.getElementById('txtagencycode').value=dsexecute.Tables[0].Rows[x].Agency_Type_Code;
		document.getElementById('txtagencyname').value=dsexecute.Tables[0].Rows[x].Agency_Type_Name;
			document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[x].Agency_Type_Alias;
		document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[x].Creditdays;	
		document.getElementById('hiddenuniqueid').value=dsexecute.Tables[0].Rows[x].Ad_typeuniqueid;
		document.getElementById('drpmrvno').value=dsexecute.Tables[0].Rows[x].MRVREF;	
			document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[x].PAM_TARGET_TABLENAME;	
				document.getElementById('drpmonthenddate').value=dsexecute.Tables[0].Rows[x].MONTH_END_BILLDT_REQ;	
		
		
		//code for date
		
		var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(dsexecute.Tables[0].Rows[x].Effective_From != null && dsexecute.Tables[0].Rows[x].Effective_From != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[x].Effective_From;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefffrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefffrom').value="";
			}
			
			if(dsexecute.Tables[0].Rows[x].Effective_Till != null && dsexecute.Tables[0].Rows[x].Effective_Till != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[x].Effective_Till;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefftill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtefftill').value="";
			}
		
				document.getElementById('txtcommrate').value=dsexecute.Tables[0].Rows[x].Comm_Rate;
				document.getElementById('drpcommdetail').value=dsexecute.Tables[0].Rows[x].Comm_Apply;
				
				document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[x].Creditdays;
				document.getElementById('drpadcat').value=dsexecute.Tables[0].Rows[x].Ad_category;
				document.getElementById('drpcommisionreq').value=dsexecute.Tables[0].Rows[x].COMM_REQ;
				
		
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
		return false;
}

function atmExitclick()
{
	if(confirm("Do You Want To Skip This Page"))
	{
		//window.location.href='enterpage.aspx';
	 window.close();
		return false;
	}
	else
	{
		return false;
	}
}
/*--------------------------------------------------------------------------------*/
function uppercase1()
{
document.getElementById('txtagencycode').value=document.getElementById('txtagencycode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtagencyname').value=document.getElementById('txtagencyname').value.toUpperCase();
	//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
	if(hiddentext=="new")
    {
        document.getElementById('txtalias').value=document.getElementById('txtagencyname').value;
    }
document.getElementById('txtalias').focus();
//return ;
}

function uppercase3()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
return ;
}
		
function charval()
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function charval1()
{
if((event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

function atmDeleteclick()
{
		var companycode=document.getElementById('hiddencomcode').value;
		var code=document.getElementById('txtagencycode').value;
		var name=document.getElementById('txtagencyname').value;
		var alias=document.getElementById('txtalias').value;
		var UserId=document.getElementById('hiddenuserid').value;	
		//var uniqueid=document.getElementById('txtagencycode').value + document.getElementById('drpadcat').value;	
		var uniqueid=document.getElementById('hiddenuniqueid').value;
		boolReturn = confirm("Are you sure you wish to delete this?");
	

	if(boolReturn==1)
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
AgencyTypeMaster.atmdelete(companycode,code,name,alias,UserId,uniqueid, ip2);	

		AgencyTypeMaster.atmexecute(companycode,gbatmcode,gbatmname,gbatmalias,UserId,delcall);
			
		}     
	else
	{
	return false;
	}
		return false;
}
	
function delcall(res)
{
	dsexecute= res.value;
	len=dsexecute.Tables[0].Rows.length;

	if(dsexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtagencycode').value="";
		document.getElementById('txtagencyname').value="";
			//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		document.getElementById('txtalias').value="";
		document.getElementById('txtefffrom').value="";
			document.getElementById('txtefftill').value="";
			document.getElementById('txtcommrate').value="";
			document.getElementById('drpcommdetail').value="0";
			document.getElementById('txtcreditdays').value="";
			document.getElementById('drpadcat').value="0";
			document.getElementById('drpcommisionreq').value="0";
			document.getElementById('txttargettable').value="";
		atmCancelclick('AgencyTypeMaster');
		return false;
	}
	else if(z>=len || z==-1)
	{
	
		document.getElementById('txtagencycode').value=dsexecute.Tables[0].Rows[0].Agency_Type_Code;
		document.getElementById('txtagencyname').value=dsexecute.Tables[0].Rows[0].Agency_Type_Name;
			document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_Type_Alias;
		document.getElementById('drpadcat').value=dsexecute.Tables[0].Rows[0].Ad_category;
		document.getElementById('drpcommisionreq').value=dsexecute.Tables[0].Rows[0].COMM_REQ;
		document.getElementById('hiddenuniqueid').value=dsexecute.Tables[0].Rows[0].Ad_typeuniqueid;
		document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[0].PAM_TARGET_TABLENAME;
		//code for date
		
		var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(dsexecute.Tables[0].Rows[0].Effective_From != null && dsexecute.Tables[0].Rows[0].Effective_From != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[0].Effective_From;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefffrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			
			
			}
			
			
			if(dsexecute.Tables[0].Rows[0].Effective_Till != null && dsexecute.Tables[0].Rows[0].Effective_Till != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[0].Effective_Till;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefftill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			
			
			}
		
				document.getElementById('txtcommrate').value=dsexecute.Tables[0].Rows[0].Comm_Rate;
				document.getElementById('drpcommdetail').value=dsexecute.Tables[0].Rows[0].Comm_Apply;
				
				document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[0].Creditdays;
				document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[0].PAM_TARGET_TABLENAME;
			
	}
	else
	{
		document.getElementById('txtagencycode').value=dsexecute.Tables[0].Rows[z].Agency_Type_Code;
		document.getElementById('txtagencyname').value=dsexecute.Tables[0].Rows[z].Agency_Type_Name;
			document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_Type_Alias;
			document.getElementById('drpadcat').value=dsexecute.Tables[0].Rows[z].Ad_category;
				document.getElementById('drpcommisionreq').value=dsexecute.Tables[0].Rows[z].COMM_REQ;
				document.getElementById('hiddenuniqueid').value=dsexecute.Tables[0].Rows[z].Ad_typeuniqueid;
				document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[z].PAM_TARGET_TABLENAME;
		
		//code for date
		
		var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(dsexecute.Tables[0].Rows[z].Effective_From != null && dsexecute.Tables[0].Rows[z].Effective_From != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[z].Effective_From;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefffrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefffrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefffrom').value=enrolldate1;
			}
			
			
			}
			
			
			if(dsexecute.Tables[0].Rows[z].Effective_Till != null && dsexecute.Tables[0].Rows[z].Effective_Till != "")
			{
			var validate_fromdate=dsexecute.Tables[0].Rows[z].Effective_Till;
			var dd = "";
			var mm = "";
			var yyyy = "";
			if (document.getElementById('hdnconntype').value != "mysql") {
			    dd = validate_fromdate.getDate();
			    mm = validate_fromdate.getMonth() + 1;
			    yyyy = validate_fromdate.getFullYear();
			}
			else {

			    dd = validate_fromdate.split('/')[0];
			    mm = validate_fromdate.split('/')[1];
			    yyyy = validate_fromdate.split('/')[2];
			}
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtefftill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtefftill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtefftill').value=enrolldate1;
			}
			
			
			}
		
				document.getElementById('txtcommrate').value=dsexecute.Tables[0].Rows[z].Comm_Rate;
				document.getElementById('drpcommdetail').value=dsexecute.Tables[0].Rows[z].Comm_Apply;
				
				document.getElementById('txtcreditdays').value=dsexecute.Tables[0].Rows[z].Creditdays;
				document.getElementById('txttargettable').value=dsexecute.Tables[0].Rows[z].PAM_TARGET_TABLENAME;
				
	}
	//alert(xmlObj.childNodes(0).childNodes(2).text);
		if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(2).text);
				}
		//alert("Data Deleted Successfully");	
	setButtonImages();
return false;
}

function pastealias()
{
document.getElementById('txtalias').value=document.getElementById('txtagencyname').value;
return false;
}

// ******************************Code For Auto Generation********************

function autoornot()
 {
  if(hiddentext=="new")
  {
  if(document.getElementById('hiddenauto').value==1)
    {
    autochange();
    
    return false;
    }
else
    {
    userdefine();

    return false;
    }
    }
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function autochange()
{
if(hiddentext=="new" )
			{
	
            UPPERCASE();
           
           }
            else
            {
            document.getElementById('txtagencyname').value=document.getElementById('txtagencyname').value.toUpperCase();
            	document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
            }
return false;
}


//auto generated
//this is used for increment in code

function UPPERCASE()
		{
		document.getElementById('txtagencyname').value=document.getElementById('txtagencyname').value.toUpperCase();
			
		document.getElementById('txtagencyname').value=trim(document.getElementById('txtagencyname').value);
		//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		  document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
		    document.getElementById('txtalias').focus();
		  lstr=document.getElementById('txtagencyname').value;
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
		
		    if(document.getElementById('txtagencyname').value!="")
                {
                 
        
		document.getElementById('txtagencyname').value=document.getElementById('txtagencyname').value.toUpperCase();
		//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
	    document.getElementById('txtalias').value=document.getElementById('txtagencyname').value;
		//str=document.getElementById('txtagencyname').value;
		str=mstr;
		AgencyTypeMaster.chkagencytype(str,fillcall);
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
		    alert("This Agency Type name has already assigned !! ");
		    document.getElementById('txtagencyname').value="";
			//document.getElementById('txtagencycode').value="";
			document.getElementById('txtalias').value="";
		
		    document.getElementById('txtagencyname').focus();
    		
		    return false;
		    }
//		
//		        else
//		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Agency_Type_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        //var code=newstr.substr(2,4);
		                        str=str.toUpperCase();
		                        code++;
		                        document.getElementById('txtagencycode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                            str=str.toUpperCase();
		                          document.getElementById('txtagencycode').value=str.substr(0,2)+ "0";
		                          }
		     //}
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtagencycode').disabled=false;
        document.getElementById('txtagencyname').value=document.getElementById('txtagencyname').value.toUpperCase();
        document.getElementById('txtagencyname').value=trim(document.getElementById('txtagencyname').value);
        //document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
        document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
        document.getElementById('txtalias').value=document.getElementById('txtagencyname').value;
        document.getElementById('txtalias').focus();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

//return false;
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

function chklimit()
{
if(document.getElementById('txtcreditdays').value!="")
{
        var limit=document.getElementById('txtcreditdays').value;
        var i=parseFloat(limit)
        //alert(i);
        if(i>=0 && i<=365)
        {
        return true
        }
        else
        {
        alert("Credit Days cannot exceed 365 days ");
        document.getElementById('txtcreditdays').value="";
        document.getElementById('txtcreditdays').focus();
        return false;
        }
}
return false;
}

function amount(e)
		{
		  //var commissionrate=document.getElementById('txtcommrate').value;
		//var fld =document.getElementById('txtcommrate').value;
		var fld=e.value;
		var per=parseFloat(e.value);
		if(per>100)
		{
		    alert("Commission Rate% Should not be greater than 100% ");
		    e.value="";
		    return false;
		}
		else if(fld.indexOf("..")>=0)
			{
			   alert("Input Error");
			   document.getElementById('txtcommrate').value="";
			  return false;
			}
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			//alert(e.id);
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			//e.id.focus();
			return false;
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
function blankagency()
{
loadXML('xml/errorMessage.xml');
givebuttonpermission('AgencyTypeMaster');
document.getElementById('btnNew').focus();
atmCancelclick('AgencyTypeMaster');






}

function agency_typ_slab() {

    var txtagencycode;
    if (document.getElementById('txtagencycode').value == "" || document.getElementById('txtagencycode').value == null) {

        alert("select agency type name");
       
             return false;

    }

    else {


        var agency_type_code = document.getElementById('txtagencycode').value;

        window.open('agency_type_slab.aspx?agency_type_code=' + agency_type_code + "&d=" + d, 'Ankur1', 'toolbar=0,resizable=0,top=244,left=210,scrollbars=yes,width=780px,height=415px');
    }

return false;
}



