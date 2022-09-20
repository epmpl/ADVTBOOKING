var z=0;
var flag="0";
var chkstate;
var chkstatename;
var statcode;
var distcode;
var hiddentext;
var chkdist;
var chkdistname;
var auto="";
var hiddentext1="";
var dscityexecute;
var gbcitycode;
var gbcityname;
var gbalias;
var gbdistrict;
var gbstatename;
var gbzonename;
var gbcountry;
var gbcitystd;
var gbregion;

var chknamemod;


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
    Citycancel('CityMaster');

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

/*-----For---Upper Case-------------*/
function uppercase1()
{
document.getElementById('txtCityCode').value=document.getElementById('txtCityCode').value.toUpperCase();
return ;
}

function uppercase2()
{
document.getElementById('txtAlias').value=document.getElementById('txtAlias').value.toUpperCase();
return ;
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
//====Bind Region=======
function fillregion()
{

var code=document.getElementById('drpZoneName').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if(code!="0")
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
response=CityMaster.bindregion(code,compcode,userid);
    var ds=response.value;
    var i;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;


    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
       
                var name=document.getElementById('drpRegion');
                name.options[0]=new Option("----Select Region----","0");
    //            var dis=document.getElementById('drpRegion');
    //            dis.options.length=0;
    //            dis.options[0]=new Option("----Select Region----","0");

                name.options.length=1;


            for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
            {
            name.options[name.options.length]=new Option(ds.Tables[0].Rows[i].Region_Name,ds.Tables[0].Rows[i].Region_Code);
            name.options.length;
            }
       
//            if(statcode == undefined || statcode=="")
//             {
//              document.getElementById('drpStateName').value="0";
//             
//             }
//             else
//             {
//              document.getElementById('drpStateName').value=statcode;
//              statcode="";
//              } 
    }
    else
        {
      //  alert("There is No Matching value Found");
                 var name=document.getElementById('drpRegion');
                 name.options.length=0;
                name.options[0]=new Option("----Select Region----","0");
    //            var dis=document.getElementById('drpDistrictName');
    //            dis.options.length=0;
    //            dis.options[0]=new Option("----Select District----","0");
        return false;

        }
   // document.getElementById('drpRegion').disabled=false;
}
else
{
             var name=document.getElementById('drpRegion');
             name.options.length=0;
            name.options[0]=new Option("----Select Region----","0");
//            var dis=document.getElementById('drpRegion');
//            dis.options.length=0;
//            dis.options[0]=new Option("----Select Region----","0");
}
return false;
}

function call_pac11(response)
{
var ds=response.value;
var i;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;


if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
   
            var name=document.getElementById('drpRegion');
            name.options[0]=new Option("----Select Region----","0");
//            var dis=document.getElementById('drpRegion');
//            dis.options.length=0;
//            dis.options[0]=new Option("----Select Region----","0");

            name.options.length=1;


        for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
        {
        name.options[name.options.length]=new Option(ds.Tables[0].Rows[i].Region_Name,ds.Tables[0].Rows[i].Region_Code);
        name.options.length;
        }
   
//        if(statcode == undefined || statcode=="")
//         {
//          document.getElementById('drpStateName').value="0";
//         
//         }
//         else
//         {
//          document.getElementById('drpStateName').value=statcode;
//          statcode="";
//          } 
}
else
    {
  //  alert("There is No Matching value Found");
             var name=document.getElementById('drpRegion');
             name.options.length=0;
            name.options[0]=new Option("----Select Region----","0");
//            var dis=document.getElementById('drpDistrictName');
//            dis.options.length=0;
//            dis.options[0]=new Option("----Select District----","0");
    return false;

    }
return false;
}
//**************//**********************************//*******************************//
function fillcountry()
{

var code=document.getElementById('drpCountryName').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if(code!="0")
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
CityMaster.bindstate(code,compcode,userid,call_pac1);
    document.getElementById('drpStateName').disabled=false;
}
else
{
             var name=document.getElementById('drpStateName');
             name.options.length=0;
            name.options[0]=new Option("----Select State----","0");
            var dis=document.getElementById('drpDistrictName');
            dis.options.length=0;
            dis.options[0]=new Option("----Select District----","0");
}
return false;
}

function call_pac1(response)
{
var ds=response.value;
var i;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;


if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
   
            var name=document.getElementById('drpStateName');
            name.options[0]=new Option("----Select State----","0");
            var dis=document.getElementById('drpDistrictName');
            dis.options.length=0;
            dis.options[0]=new Option("----Select District----","0");

            name.options.length=1;


        for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
        {
        name.options[name.options.length]=new Option(ds.Tables[0].Rows[i].State_Name,ds.Tables[0].Rows[i].State_Code);
        name.options.length;
        }
   
        if(statcode == undefined || statcode=="")
         {
          document.getElementById('drpStateName').value="0";
         
         }
         else
         {
          document.getElementById('drpStateName').value=statcode;
          statcode="";
          } 
}
else
    {
  //  alert("There is No Matching value Found");
             var name=document.getElementById('drpStateName');
             name.options.length=0;
            name.options[0]=new Option("----Select State----","0");
            var dis=document.getElementById('drpDistrictName');
            dis.options.length=0;
            dis.options[0]=new Option("----Select District----","0");
    return false;

    }
return false;
}

//var state = document.getElementById('drpStateName').value;
// var statename;
//		         var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		        xml.Open( "GET","distbind.aspx?statename="+state, false );
//		        xml.Send();
//	            var id=xml.responseText;
//	            alert(id);
//	            
//	            
//	            var drpid=id.split("#");
//	            for(var i=0;i<)
////var txt1=txt.split("/");
////var dd=txt1[0];
////var mm=txt1[1];
////var yy=txt1[2];
////var txtdob=mm+'/'+dd+'/'+yy;
	            
	            
	            
	            
	            
//	            
//	            var i;
//if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
//{
//        var bindname=document.getElementById('drpDistrictName');
//        bindname.options[0]=new Option("--Select District--","0");

//        bindname.options.length=1;

//        for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
//        {
//        bindname.options[bindname.options.length]=new Option(ds.Tables[0].Rows[i].Dist_Name,ds.Tables[0].Rows[i].Dist_Code);
//        bindname.options.length;
//        }
// if(distcode == undefined || distcode=="")
//         {
//          document.getElementById('drpDistrictName').value="0";
//         
//         }
//         else
//         {
//          document.getElementById('drpDistrictName').value=distcode;
//          distcode="";
//          } 
////}
//else
//{
//alert("There is No Matching value Found");
//return false;

//}
















//return false;
//}

function fillstate()
{
    var code1=document.getElementById('drpStateName').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
    /*new change ankur 10 feb*/
    if(document.getElementById('hiddenHindustan').value=="Hindustan")
    {
            if(code1!="0")
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
CityMaster.binddistrict(code1,compcode,userid,call_pac); 
                document.getElementById('drpDistrictName').disabled=false; 
            }
            else
            {
                    var bindname=document.getElementById('drpDistrictName');
                    bindname.options.length=0;
                    bindname.options[0]=new Option("----Select District----","0");

            }
    }
    return false;
}

function call_pac(response)
{
var ds=response.value;
var i;
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
        var bindname=document.getElementById('drpDistrictName');
        bindname.options[0]=new Option("----Select District----","0");

        bindname.options.length=1;

        for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
        {
            bindname.options[bindname.options.length]=new Option(ds.Tables[0].Rows[i].Dist_Name,ds.Tables[0].Rows[i].Dist_Code);
            bindname.options.length;
        }
 if(distcode == undefined || distcode=="")
         {
          document.getElementById('drpDistrictName').value="0";
         
         }
         else
         {
          document.getElementById('drpDistrictName').value=distcode;
          distcode="";
          } 
}
else
{
//alert("There is No Matching value Found");
var bindname=document.getElementById('drpDistrictName');
bindname.options.length=0;
bindname.options[0]=new Option("----Select District----","0");
return false;

}
return false;
}


function Citynew()
{
            var msg=checkSession();
            if(msg==false)
            return false;
			document.getElementById('txtCityCode').value="";
			document.getElementById('txtCityName').value="";
			document.getElementById('txtAlias').value="";
			document.getElementById('drpDistrictName').value="0";
			document.getElementById('drpStateName').value="0";
			document.getElementById('drpZoneName').value="0";
			document.getElementById('drpCountryName').value="0";
			document.getElementById('txtCitySTD').value="";
			document.getElementById('drpRegion').value="0";
            document.getElementById('txtbranch').value="0";
            
			if(document.getElementById('hiddenauto').value==1)
			{
			document.getElementById('txtCityCode').disabled=true;
			
			}
			else
			{
			document.getElementById('txtCityCode').disabled=false;
			
			}
  
			document.getElementById('txtCityName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			document.getElementById('drpDistrictName').disabled=false;
			document.getElementById('drpStateName').disabled=false;
			document.getElementById('drpZoneName').disabled=false;
			document.getElementById('drpCountryName').disabled=false;
			document.getElementById('txtCitySTD').disabled=false;
			document.getElementById('drpRegion').disabled=false;
			document.getElementById('txtbranch').disabled=false;
			
			if(document.getElementById('hiddenauto').value==1)
			{
			document.getElementById('drpCountryName').focus();
			
			}
			else
			{
			document.getElementById('drpCountryName').focus();
			
			}

			chkstatus(FlagStatus);
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
			flag=0;
			hiddentext="new";
			//if(hiddentext1=="clear")
			//{
			hiddentext1="";
		//	document.getElementById('btnSave').disabled=false;	
			//}
			setButtonImages();
			return false;
}

function Citycancel(formname)
{
            //hiddentext1="clear";
            givebuttonpermission(formname);
            document.getElementById('txtCityCode').disabled=false;
			
			document.getElementById('txtCityCode').value="";
			document.getElementById('txtCityName').value="";
			document.getElementById('txtAlias').value="";
			document.getElementById('drpStateName').options.length=0;
            document.getElementById('drpStateName').options[0]=new Option("----Select State----","0");
			//document.getElementById('drpDistrictName').value="0";
			document.getElementById('drpDistrictName').options.length=0;
            document.getElementById('drpDistrictName').options[0]=new Option("----Select District ----","0");
			//document.getElementById('drpStateName').value="0";
			document.getElementById('drpZoneName').value="0";
			document.getElementById('drpCountryName').value="0";
			document.getElementById('txtCitySTD').value="";
			//document.getElementById('drpRegion').value="0";
			document.getElementById('drpRegion').options.length=0;
            document.getElementById('drpRegion').options[0]=new Option("----Select State----","0");
            document.getElementById('txtbranch').value="0";
            
			document.getElementById('txtCityCode').disabled=true;
			document.getElementById('txtCityName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			document.getElementById('drpDistrictName').disabled=true;
			document.getElementById('drpStateName').disabled=true;
			document.getElementById('drpZoneName').disabled=true;
			document.getElementById('drpCountryName').disabled=true;
			document.getElementById('txtCitySTD').disabled=true;
			document.getElementById('drpRegion').disabled=true;
			 document.getElementById('txtbranch').disabled=true;
			//document.getElementById('btnNew').disabled=false;
			if(document.getElementById('btnNew').disabled==false)
			{
			    document.getElementById('btnNew').focus();
			}
			
			
			/*document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled= true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled= false;
			document.getElementById('btnExecute').disabled= true;
			document.getElementById('btnCancel').disabled=false;				
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;				
			document.getElementById('btnlast').disabled=true;				
			document.getElementById('btnExit').disabled=false;*/

			//getPermission(formname);
setButtonImages();
			return false;
}


function Citymodify()
{
			flag=1;
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnExit').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExit').disabled=false;*/
			hiddentext="modify";
			
			chkstatus(FlagStatus);
			
			document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
			document.getElementById('txtCityCode').disabled=true;
			document.getElementById('txtCityName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			document.getElementById('drpDistrictName').disabled=false;//false
			document.getElementById('drpStateName').disabled=false;//false
			document.getElementById('txtbranch').disabled=false;
			
			chknamemod=document.getElementById('txtCityName').value;
			//fillcountry();
		
			//name.options[0]=new Option(chkstatename,chkstate);
			
			//bindname.options[0]=new Option(chkdistname,chkdist);
			
		//	document.getElementById('drpStateName').value=chkstate;
		//	document.getElementById('drpDistrictName').value=chkdist;
			
			document.getElementById('drpCountryName').disabled=false;
			document.getElementById('txtCitySTD').disabled=false;
			document.getElementById('drpRegion').disabled=false;
			document.getElementById('drpZoneName').disabled=false;
			document.getElementById('txtCityName').focus();
			setButtonImages();
			return false;
}



function fillcountry12()
{

var code=document.getElementById('drpCountryName').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

response=CityMaster.bindstate(code,compcode,userid);
var ds=response.value;
var i;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;


if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
   
            var name=document.getElementById('drpStateName');
            name.options[0]=new Option("----Select State----","0");

            name.options.length=1;

            for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
            {
            name.options[name.options.length]=new Option(ds.Tables[0].Rows[i].State_Name,ds.Tables[0].Rows[i].State_Code);
            name.options.length;
            }
//            if(statcode == undefined || statcode=="")
//             {
//              document.getElementById('drpStateName').value="0";
//             
//             }
//             else
//             {
//              document.getElementById('drpStateName').value=statcode;
//              CityMaster.binddistrict(statcode, compcode, userid,call_pac125); 
//              document.getElementById('drpDistrictName').disabled=true; 
//              statcode="";
//              } 
}
else
    {
   // alert("There is No Matching value Found");
    return false;

    }
document.getElementById('drpStateName').disabled=true;
//return false;
}

function call_pac12(response)
{
var ds=response.value;
var i;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;


if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
   
            var name=document.getElementById('drpStateName');
            name.options[0]=new Option("----Select State----","0");

            name.options.length=1;

            for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
            {
            name.options[name.options.length]=new Option(ds.Tables[0].Rows[i].State_Name,ds.Tables[0].Rows[i].State_Code);
            name.options.length;
            }
            if(statcode == undefined || statcode=="")
             {
              document.getElementById('drpStateName').value="0";
             
             }
             else
             {
              document.getElementById('drpStateName').value=statcode;
              CityMaster.binddistrict(statcode, compcode, userid,call_pac125); 
              document.getElementById('drpDistrictName').disabled=true; 
              statcode="";
              } 
}
else
    {
   // alert("There is No Matching value Found");
    return false;

    }
return false;
}
function binddist()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
statcode=document.getElementById('drpStateName').value;
var response=CityMaster.binddistrict(statcode, compcode, userid); 
var ds=response.value;
var i;
/*NEW CHANGE ANKUR 11 FEB*/
if(document.getElementById('hiddenHindustan').value=="Hindustan")
    {
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
                    var bindname=document.getElementById('drpDistrictName');
                    bindname.options[0]=new Option("----Select District----","0");

                    bindname.options.length=1;

                    for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
                    {
                    bindname.options[bindname.options.length]=new Option(ds.Tables[0].Rows[i].Dist_Name,ds.Tables[0].Rows[i].Dist_Code);
                    bindname.options.length;
                    }
             if(distcode == undefined || distcode=="")
                     {
                      document.getElementById('drpDistrictName').value="0";
                     
                     }
                     else
                     {
                      document.getElementById('drpDistrictName').value=distcode;
                      distcode="";
                      } 
            }
            else
            {
                  document.getElementById('drpDistrictName').options.length=0;
            document.getElementById('drpDistrictName').options[0]=new Option("----Select District----","0");
           // alert("There is No Matching value Found");
            return false;

            }
  }
return false;
}








function Citysave()
{
var msg=checkSession();
    if(msg==false)
    return false;
 document.getElementById('txtCityName').value=trim(document.getElementById('txtCityName').value);
 document.getElementById('txtCityCode').value=trim(document.getElementById('txtCityCode').value);
 document.getElementById('txtAlias').value=trim(document.getElementById('txtAlias').value);
        if(document.getElementById('drpCountryName').value=="0" || document.getElementById('drpCountryName').value=="")
        {
                    alert("Please Enter Country Name");
					document.getElementById('drpCountryName').focus();
					return false;
					}
		  else if((document.getElementById('txtCityCode').value=="")&&(document.getElementById('hiddenauto').value!=1))
              {
           
			//if (document.getElementById('txtCityCode').value=="")
			     //{
					alert("Please Enter City Code");
					document.getElementById('txtCityCode').focus();
					return false;
			     }
		      
			
			else if (document.getElementById('txtCityName').value=="")
			{
					alert("Please Enter City Name");
					document.getElementById('txtCityName').focus();
					return false;
			}
			else if (document.getElementById('txtAlias').value=="")
			{
					alert("Please Enter Alias");
					document.getElementById('txtAlias').focus();
					return false;
			}
			else if (document.getElementById('drpCountryName').value=="0")
			{
					alert("Please Select Country Name");
					document.getElementById('drpCountryName').focus();
					return false;
			}
			else if (document.getElementById('drpStateName').value=="0")
			{
					alert("Please Select State Name");
					document.getElementById('drpStateName').focus();
					return false;
			}
			
			else if (document.getElementById('drpRegion').value=="0" || document.getElementById('drpRegion').value=="")
			{
					alert("Please Select Region Name");
					document.getElementById('drpRegion').focus();
					return false;
			}
		
			else if (document.getElementById('txtCitySTD').value=="")
			{
					alert("Please Enter S.T.D Code");
					document.getElementById('txtCitySTD').focus();
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
			else
			{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var CityCode=document.getElementById('txtCityCode').value;
				var CityName=document.getElementById('txtCityName').value;
				var Alias=document.getElementById('txtAlias').value;
				var CountryName=document.getElementById('drpCountryName').value;
				var StateName=document.getElementById('drpStateName').value;
				var ZoneName=document.getElementById('drpZoneName').value;
				var DistrictName=document.getElementById('drpDistrictName').value;
				var CitySTD=document.getElementById('txtCitySTD').value;
				var Region=document.getElementById('drpRegion').value;
				
				if(flag!="1" && flag!=null)
				{//save
          
                  CityMaster.citycheck(CityCode,compcode,CityName,CountryName,StateName,DistrictName,"save",call_saveclick);
				}
				else
				{
					
					//CityMaster.citycheck(CityCode,compcode,CityName,CountryName,StateName,DistrictName,"modify",call_modifyclick);
					var str=document.getElementById('txtCityName').value;
					  CityMaster.chkcode(str,CountryName,call_modifyclick);
					
				}
			}
			return false;
//}
}

function call_modifyclick(res)
{
        var ds=res.value;
        if(chknamemod!=document.getElementById('txtCityName').value)
        {
            if(ds.Tables[0].Rows.length!=0)
            {
                alert("This City name has already assigned !! ");
                document.getElementById('txtCityName').value="";
                document.getElementById('txtCityName').focus();
                return false;
            }
        }
    
		
                
		        var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var CityCode=document.getElementById('txtCityCode').value;
				var CityName=document.getElementById('txtCityName').value;
				var Alias=document.getElementById('txtAlias').value;
				var CountryName=document.getElementById('drpCountryName').value;
				var StateName=document.getElementById('drpStateName').value;
				var ZoneName=document.getElementById('drpZoneName').value;
				var DistrictName=document.getElementById('drpDistrictName').value;
				var CitySTD=document.getElementById('txtCitySTD').value;
				var Region=document.getElementById('drpRegion').value;
      //---------------------- update branchlist --------------------------------//
                var branchlist="";
                for(var li=1;  li< document.getElementById('txtbranch').options.length; li++)
                {
//                    if (document.getElementById('txtbranch').options[li].selected == true)
//                    {
//                        if(branchlist=="")
//                             branchlist=document.getElementById('txtbranch').options[li].value;
//                        else
//                            branchlist=branchlist + "," + document.getElementById('txtbranch').options[li].value;
//                    }
                      if (document.getElementById('txtbranch').options[li].selected == true)
                            {
                               userflag="Y";
                               var branchcode=document.getElementById('txtbranch').options[li].value;
                            }
                            else
                            {
                               userflag="N";
                               var branchcode=document.getElementById('txtbranch').options[li].value;
                            }
                           
                           // Createuser.savebranchpermission(userid,branchcode,userflag,companycode);
                            CityMaster.updatebranch(userid,branchcode,compcode,CityCode,userflag);
                 //    CityMaster.updatebranch(userid,branchcode,compcode);
                }
               
//                var data=branchlist.split(",");
//                for(t=0; t<data.length; t++)
//                {
//                   CityMaster.updatebranch(userid,data[t],compcode,CityCode);
//                }
                //------------------------------------------------------------------//      
            var ip2=document.getElementById('ip1').value;
               CityMaster.modify(CityCode,CityName,Alias,DistrictName,StateName,ZoneName,CountryName,CitySTD,Region,compcode,userid,ip2);
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
		            alert(xmlObj.childNodes(0).childNodes(1).text);
		        }
			
					//alert("Data Modified Successfully");
					dscityexecute.Tables[0].Rows[z].City_Name=document.getElementById('txtCityName').value;
		            dscityexecute.Tables[0].Rows[z].City_Alias=document.getElementById('txtAlias').value;
		            dscityexecute.Tables[0].Rows[z].State_Code=document.getElementById('drpStateName').value;
	                dscityexecute.Tables[0].Rows[z].Dist_Code=document.getElementById('drpDistrictName').value;
			        dscityexecute.Tables[0].Rows[z].Zone_Code=document.getElementById('drpZoneName').value;
		            dscityexecute.Tables[0].Rows[z].Country_Code=document.getElementById('drpCountryName').value;
		            dscityexecute.Tables[0].Rows[z].STD_Code=document.getElementById('txtCitySTD').value;
		            dscityexecute.Tables[0].Rows[z].Region_Code=document.getElementById('drpRegion').value;
		            
                updateStatus();
					
					document.getElementById('txtCityCode').disabled=true;
					document.getElementById('txtCityName').disabled=true;
					document.getElementById('txtAlias').disabled=true;
					document.getElementById('drpDistrictName').disabled=true;
					document.getElementById('drpStateName').disabled=true;
					document.getElementById('drpZoneName').disabled=true;
					document.getElementById('drpCountryName').disabled=true;
					document.getElementById('txtCitySTD').disabled=true;
					document.getElementById('drpRegion').disabled=true;
					document.getElementById('txtbranch').disabled=true;
					document.getElementById('btnModify').focus();
					
					if (z==0)
                      {
                      document.getElementById('btnfirst').disabled=true;
                        document.getElementById('btnprevious').disabled=true;
 			        }		
 			        if(z==(dscityexecute.Tables[0].Rows.length-1))
 			        {
                     document.getElementById('btnnext').disabled=true;
	                  document.getElementById('btnlast').disabled=true;
                    }
					
					
					flag="0";

setButtonImages();
}

function call_saveclick(response)
{
			var ds=response.value;
		   if(document.getElementById('txtCityCode').value=="")
			{
			    alert("Please Enter City Code");
			    if(document.getElementById('txtCityCode').disabled==false)
				{
				    document.getElementById('txtCityCode').focus();
				}
			    return false;
			}
		
		   
			if(ds.Tables[0].Rows.length > 0 || ds.Tables[1].Rows.length>0)
			{
                   if(ds.Tables[0].Rows.length > 0 )
			        {			
				        alert("This City Code Is Already Exist, Try Another Code !!!!");
				         document.getElementById('txtCityCode').value="";
				        if(document.getElementById('txtCityCode').disabled==false)
				        {
				        document.getElementById('txtCityCode').focus();
				        return false;
				        }
				    }
				    else
				    {
				        alert("This City Name Is Already Exist");
				        document.getElementById('txtCityName').value="";
				        document.getElementById('txtAlias').value="";
				        document.getElementById('txtCityName').focus();
				    }
				        return false;
			} 
			else
			{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var CityCode=document.getElementById('txtCityCode').value;
				var CityName=document.getElementById('txtCityName').value;
				var Alias=document.getElementById('txtAlias').value;
				var CountryName=document.getElementById('drpCountryName').value;
				var StateName=document.getElementById('drpStateName').value;
				var ZoneName=document.getElementById('drpZoneName').value;
				var DistrictName=document.getElementById('drpDistrictName').value;
				var CitySTD=document.getElementById('txtCitySTD').value;
				var Region=document.getElementById('drpRegion').value;
                
                //---------------------- save branch --------------------------------//
                var branchlist="";
                for(var li=1;  li< document.getElementById('txtbranch').options.length; li++)
                {
//                    if (document.getElementById('txtbranch').options[li].selected == true)
//                    { 
//                    
//                        if(branchlist=="")
//                             branchlist=document.getElementById('txtbranch').options[li].value;
//                        else
//                            branchlist=branchlist + "," + document.getElementById('txtbranch').options[li].value;
//                    }

                           if (document.getElementById('txtbranch').options[li].selected == true)
                            {
                               userflag="Y";
                               var branchcode=document.getElementById('txtbranch').options[li].value;
                            }
                            else
                            {
                               userflag="N";
                               var branchcode=document.getElementById('txtbranch').options[li].value;
                            }
                           
                           // Createuser.savebranchpermission(userid,branchcode,userflag,companycode);
                            CityMaster.savebranch(userid,branchcode,compcode,CityCode,userflag);
                    
                 //    CityMaster.savebranch(userid,branchcode,compcode);
                }
               
//                var data=branchlist.split(",");
//                for(t=0; t<data.length; t++)
//                {
//                   CityMaster.savebranch(userid,data[t],compcode,CityCode);
//                }
                //------------------------------------------------------------------//   
                var ip2=document.getElementById('ip1').value;   
				CityMaster.insert(CityCode,CityName,Alias,DistrictName,StateName,ZoneName,CountryName,CitySTD,Region,compcode,userid,ip2);				
				if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
		            alert(xmlObj.childNodes(0).childNodes(0).text);
		        }
				  //return false;
			
				//alert("Data Saved Successfully");
					updateStatus();				
				document.getElementById('txtCityCode').value="";
				document.getElementById('txtCityName').value="";
				document.getElementById('txtAlias').value="";
				document.getElementById('drpDistrictName').value="0";
				document.getElementById('drpStateName').value="0";
				document.getElementById('drpZoneName').value="0";
				document.getElementById('drpCountryName').value="0";
				document.getElementById('txtCitySTD').value="";	
				document.getElementById('drpRegion').value="0";
				
				document.getElementById('txtCityCode').disabled=true;
				document.getElementById('txtCityName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				document.getElementById('drpDistrictName').disabled=true;
				document.getElementById('drpStateName').disabled=true;
				document.getElementById('drpZoneName').disabled=true;
				document.getElementById('drpCountryName').disabled=true;
				document.getElementById('txtCitySTD').disabled=true;
				document.getElementById('drpRegion').disabled=true;
				document.getElementById('txtbranch').disabled=true;

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
            Citycancel('CityMaster');
			return false;
}

function Cityquery()
{
			hiddentext="query";
			document.getElementById('txtCityCode').value="";
			document.getElementById('txtCityName').value="";
			document.getElementById('txtAlias').value="";
			//document.getElementById('drpDistrictName').value="0";
			document.getElementById('drpDistrictName').options.length=0;
            document.getElementById('drpDistrictName').options[0]=new Option("----Select District ----","0");
			//document.getElementById('drpStateName').value="0";
			 document.getElementById('drpStateName').options.length=0;
            document.getElementById('drpStateName').options[0]=new Option("----Select State----","0");
			document.getElementById('drpZoneName').value="0";
			document.getElementById('drpCountryName').value="0";
			document.getElementById('txtCitySTD').value="";
			//document.getElementById('drpRegion').value="0";
			document.getElementById('drpRegion').options.length=0;
            document.getElementById('drpRegion').options[0]=new Option("----Select State----","0");
						
			chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
				
			
				
			document.getElementById('txtCityCode').disabled=false;
			document.getElementById('txtCityName').disabled=false;
			document.getElementById('txtAlias').disabled=false;
			document.getElementById('drpDistrictName').disabled=false;
			document.getElementById('drpStateName').disabled=false;
			document.getElementById('drpZoneName').disabled=false;
			document.getElementById('drpCountryName').disabled=false;
			document.getElementById('txtCitySTD').disabled=false;
			document.getElementById('drpRegion').disabled=false;
			
			setButtonImages();
		
			document.getElementById('btnExecute').focus();
			
			
			return false;
}

function Cityexecute()
{
            var msg=checkSession();
            if(msg==false)
            return false;
            
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var CityCode=document.getElementById('txtCityCode').value;
		    gbcitycode=CityCode;
			var CityName=document.getElementById('txtCityName').value;
			gbcityname=CityName;
			var Alias=document.getElementById('txtAlias').value;
			gbalias=Alias;
			var DistrictName=document.getElementById('drpDistrictName').value;
			gbdistrict=DistrictName;
			var StateName=document.getElementById('drpStateName').value;
			gbstatename=StateName;
			var ZoneName=document.getElementById('drpZoneName').value;
			gbzonename=ZoneName;
			var CountryName=document.getElementById('drpCountryName').value;
			gbcountry=CountryName;
			var CitySTD=document.getElementById('txtCitySTD').value;
			gbcitystd=CitySTD;
			var Region=document.getElementById('drpRegion').value;
			gbregion=Region;

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
    //string compcode, string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string userid
              CityMaster.select(compcode,CityCode, CityName, Alias, DistrictName, StateName, ZoneName, CountryName, CitySTD, Region, userid, call_Execute);
		updateStatus();
			
	
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();
		/*	document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled= true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			
			document.getElementById('btnCancel').disabled=false;				
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;				
			document.getElementById('btnlast').disabled=false;				
			document.getElementById('btnExit').disabled=false;*/

			return false;
}

function call_Execute(response)
{
	    dscityexecute=response.value;
	    if(dscityexecute==null)
			{
			    alert(response.error.description);
			    return false;
			}    
		if(dscityexecute.Tables[0].Rows.length>0)
		{
				
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				
				//CityMaster.distselect(compcode,userid,statcode,distcode,call_city); 
				
				document.getElementById('txtCityCode').value=dscityexecute.Tables[0].Rows[0].City_Code;
				document.getElementById('txtCityName').value=dscityexecute.Tables[0].Rows[0].City_Name;
				document.getElementById('txtAlias').value=dscityexecute.Tables[0].Rows[0].City_Alias;
				document.getElementById('drpCountryName').value=dscityexecute.Tables[0].Rows[0].Country_Code;
				document.getElementById('drpZoneName').value=dscityexecute.Tables[0].Rows[0].Zone_Code;
				fillregion();
				//CityMaster.bindregion(dscityexecute.Tables[0].Rows[0].Zone_Code,compcode,userid,call_pac11);
				document.getElementById('drpRegion').value=dscityexecute.Tables[0].Rows[0].Region_Code;
				document.getElementById('txtCitySTD').value=dscityexecute.Tables[0].Rows[0].STD_Code;
				fillcountry12();
				document.getElementById('drpStateName').value=dscityexecute.Tables[0].Rows[0].State_Code;
				binddist();
				
				document.getElementById('drpDistrictName').value=dscityexecute.Tables[0].Rows[0].Dist_Code;
				
				
//				document.getElementById('btnfirst').disabled=true;
//				document.getElementById('btnprevious').disabled=true;
				
				//-----------------------------------------------------------------------//
				 var dsbranch=CityMaster.branchexecute(compcode,dscityexecute.Tables[0].Rows[0].City_Code);
				 if(dsbranch.value==null)
				 {
				    return false;
				 }
				 var branchlist = dsbranch.value.Tables[0].Rows.length;	
                  for(var t=0;t<document.getElementById('txtbranch').options.length;t++)
                    {
                         document.getElementById('txtbranch').options[t].selected=false;
                    }
                if(branchlist!="" && branchlist!=null)
                {
                    //var data=branchlist.split(",");
                    for(var t=0;t<branchlist;t++)
                    {
                        for(var n=1;n<document.getElementById('txtbranch').options.length;n++)
                        {
                            if(dsbranch.value.Tables[0].Rows[t].branchcode==document.getElementById('txtbranch').options[n].value)
                            {
                                document.getElementById('txtbranch').options[n].selected=true;
                            }
                            
                        }
                    }
                }

//                  document.getElementById('txtbranch').options[0].selected=false; 
//                  var branchlen=dsbranch.value.Tables[0].Rows.length;
//                  var flaglen=dsbranch.value.Tables[1].Rows.length;
//                  for(var a=0; a<branchlen; a++)
//                  {
//                     document.getElementById('txtbranch').options[a].selected=false;
//                  }
//                  for(var a=0; a<branchlen; a++)
//                  {
//                    for(var i=0; i<flaglen; i++)
//                    {
//                       if(dsbranch.value.Tables[0].Rows[a].branchcode==dsbranch.value.Tables[1].Rows[i].branchcode)
//                       {
//                          document.getElementById('txtbranch').options[a+1].selected=true; 
//                          i= flaglen;
//                       }
//                    }
//                 }
				//--------------------------------------------------------------------------//
				document.getElementById('txtCityCode').disabled=true;
				document.getElementById('txtCityName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				document.getElementById('drpDistrictName').disabled=true;
				document.getElementById('drpStateName').disabled=true;
				document.getElementById('drpZoneName').disabled=true;
				document.getElementById('drpCountryName').disabled=true;
				document.getElementById('txtCitySTD').disabled=true;
				document.getElementById('drpRegion').disabled=true;
				document.getElementById('txtbranch').disabled=true;
				z=0;
				
		}
		else
		{
				Citycancel('CityMaster');

				document.getElementById('txtCityCode').disabled=true;
				document.getElementById('txtCityName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				document.getElementById('drpDistrictName').disabled=true;
				document.getElementById('drpStateName').disabled=true;
				document.getElementById('drpZoneName').disabled=true;
				document.getElementById('drpCountryName').disabled=true;
				document.getElementById('txtCitySTD').disabled=true;
				document.getElementById('drpRegion').disabled=true;

				alert("Your search criteria does not produce any result");
				return false;
		}
		
		
		if(dscityexecute.Tables[0].Rows.length==1)
		{
		    document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;				
			document.getElementById('btnlast').disabled=true;
		
		}
		if(document.getElementById('btnModify').disabled==false)
		{
			document.getElementById('btnModify').focus();
		}
		setButtonImages();
		return false;
}

function call_city(res)
{
			var ds=res.value;
			var name= document.getElementById('drpStateName');
			var bindname=document.getElementById('drpDistrictName');
			
			
			name.options[0]=new Option(ds.Tables[0].Rows[0].State_Name,ds.Tables[0].Rows[0].State_Code);
			
			bindname.options[0]=new Option(ds.Tables[1].Rows[0].Dist_Name,ds.Tables[1].Rows[0].Dist_Code);
			
			chkdist=ds.Tables[1].Rows[0].Dist_Code;
			chkdistname=ds.Tables[1].Rows[0].Dist_Name;
			
			chkstate=ds.Tables[0].Rows[0].State_Code;
			chkstatename=ds.Tables[0].Rows[0].State_Name;
			
			
			document.getElementById('drpStateName').value=name.options[0].value;
			
			document.getElementById('drpDistrictName').value=bindname.options[0].value;
		
			return false;
}

function Cityfirst()
{
        var msg=checkSession();
            if(msg==false)
            return false;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;

			var CityCode=document.getElementById('txtCityCode').value;
			var CityName=document.getElementById('txtCityName').value;
			var Alias=document.getElementById('txtAlias').value;
			var DistrictName=document.getElementById('drpDistrictName').value;
			var StateName=document.getElementById('drpStateName').value;
			var ZoneName=document.getElementById('drpZoneName').value;
			var CountryName=document.getElementById('drpCountryName').value;
			var CitySTD=document.getElementById('txtCitySTD').value;
			var Region=document.getElementById('drpRegion').value;
			
			
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
CityMaster.Selectfnpl(CityCode,CityName,Alias,DistrictName,StateName,ZoneName,CountryName,CitySTD,Region,compcode,userid,call_First);
			return false;
}

function call_First(response)
{
		z=0;
		//var ds=response.value;
			
		document.getElementById('txtCityCode').value=dscityexecute.Tables[0].Rows[z].City_Code;
		document.getElementById('txtCityName').value=dscityexecute.Tables[0].Rows[z].City_Name;
		document.getElementById('txtAlias').value=dscityexecute.Tables[0].Rows[z].City_Alias;
		
//	     statcode=dscityexecute.Tables[0].Rows[z].State_Code;
//	     distcode=dscityexecute.Tables[0].Rows[z].Dist_Code;
		    var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		
		//CityMaster.distselect(compcode,userid,statcode,distcode,call_city); 
			
			//fillstate();	
		document.getElementById('drpZoneName').value=dscityexecute.Tables[0].Rows[z].Zone_Code;
		fillregion();
		document.getElementById('drpCountryName').value=dscityexecute.Tables[0].Rows[z].Country_Code;
		document.getElementById('txtCitySTD').value=dscityexecute.Tables[0].Rows[z].STD_Code;
		document.getElementById('drpRegion').value=dscityexecute.Tables[0].Rows[z].Region_Code;
        fillcountry12();
		document.getElementById('drpStateName').value=dscityexecute.Tables[0].Rows[z].State_Code;
        binddist();
        document.getElementById('drpDistrictName').value=dscityexecute.Tables[0].Rows[z].Dist_Code;
		//-----------------------------------------------------------------------//
				 var dsbranch=CityMaster.branchexecute(compcode,dscityexecute.Tables[0].Rows[z].City_Code);
				 if(dsbranch.value==null)
				 {
				    return false;
				 }
				 var branchlist = dsbranch.value.Tables[0].Rows.length;	
                  for(var t=0;t<document.getElementById('txtbranch').options.length;t++)
                    {
                         document.getElementById('txtbranch').options[t].selected=false;
                    }
                if(branchlist!="" && branchlist!=null)
                {
                    //var data=branchlist.split(",");
                    for(var t=0;t<branchlist;t++)
                    {
                        for(var n=1;n<document.getElementById('txtbranch').options.length;n++)
                        {
                            if(dsbranch.value.Tables[0].Rows[t].branchcode==document.getElementById('txtbranch').options[n].value)
                            {
                                document.getElementById('txtbranch').options[n].selected=true;
                            }
                            
                        }
                    }
                }

//                  document.getElementById('txtbranch').options[0].selected=false; 
//                  var branchlen=dsbranch.value.Tables[0].Rows.length;
//                  var flaglen=dsbranch.value.Tables[1].Rows.length;
//                    for(var t1=0;t1<document.getElementById('txtbranch').options.length;t1++)
//                 {
//                     document.getElementById('txtbranch').options[t1].selected=false;
//                 }               
//                  for(var a=0; a<branchlen; a++)
//                  {
//                     document.getElementById('txtbranch').options[a].selected=false;
//                  }
//                  for(var a=0; a<branchlen; a++)
//                  {
//                    for(var i=0; i<flaglen; i++)
//                    {
//                       if(dsbranch.value.Tables[0].Rows[a].branchcode==dsbranch.value.Tables[1].Rows[i].branchcode)
//                       {
//                          document.getElementById('txtbranch').options[a+1].selected=true; 
//                          i= flaglen;
//                       }
//                    }
//                 }
				//--------------------------------------------------------------------------//
		updateStatus();
		if(document.getElementById('btnModify').disabled==false)
		    document.getElementById('btnModify').focus();
		
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnExit').disabled=false;
		setButtonImages();
		return false;
}


function Citynext()
{
     var msg=checkSession();
    if(msg==false)
    return false;
			var CityCode=document.getElementById('txtCityCode').value;
			var CityName=document.getElementById('txtCityName').value;
			var Alias=document.getElementById('txtAlias').value;
			var DistrictName=document.getElementById('drpDistrictName').value;
			var StateName=document.getElementById('drpStateName').value;
			var ZoneName=document.getElementById('drpZoneName').value;
			var CountryName=document.getElementById('drpCountryName').value;
			var CitySTD=document.getElementById('txtCitySTD').value;
			var Region=document.getElementById('drpRegion').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;

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
CityMaster.Selectfnpl(CityCode,CityName,Alias,DistrictName,StateName,ZoneName,CountryName,CitySTD,Region,compcode,userid,call_Next);
			
			return false;
}

function call_Next(response)
{
		z++;
		//var ds=response.value;
		var y=dscityexecute.Tables[0].Rows.length;
		var a=dscityexecute.Tables[0].Rows.length;
		var k=y-1;

		if(z !=-1 && z >= 0)
		{
		if(z <= a-1)
		{
				document.getElementById('txtCityCode').value=dscityexecute.Tables[0].Rows[z].City_Code;
				document.getElementById('txtCityName').value=dscityexecute.Tables[0].Rows[z].City_Name;
				document.getElementById('txtAlias').value=dscityexecute.Tables[0].Rows[z].City_Alias;
				
//				 statcode=dscityexecute.Tables[0].Rows[z].State_Code;
//				 distcode=dscityexecute.Tables[0].Rows[z].Dist_Code;
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
					
				
				//CityMaster.distselect(compcode,userid,statcode,distcode,call_city); 
				
				document.getElementById('drpZoneName').value=dscityexecute.Tables[0].Rows[z].Zone_Code;
				fillregion();
				document.getElementById('drpCountryName').value=dscityexecute.Tables[0].Rows[z].Country_Code;
				document.getElementById('txtCitySTD').value=dscityexecute.Tables[0].Rows[z].STD_Code;
				document.getElementById('drpRegion').value=dscityexecute.Tables[0].Rows[z].Region_Code;
                fillcountry12();
                document.getElementById('drpStateName').value=dscityexecute.Tables[0].Rows[z].State_Code;
                binddist();
                document.getElementById('drpDistrictName').value=dscityexecute.Tables[0].Rows[z].Dist_Code;
                //-----------------------------------------------------------------------//
				 var dsbranch=CityMaster.branchexecute(compcode,dscityexecute.Tables[0].Rows[z].City_Code);
				 if(dsbranch.value==null)
				 {
				    return false;
				 }
				 var branchlist = dsbranch.value.Tables[0].Rows.length;	
                  for(var t=0;t<document.getElementById('txtbranch').options.length;t++)
                    {
                         document.getElementById('txtbranch').options[t].selected=false;
                    }
                if(branchlist!="" && branchlist!=null)
                {
                    //var data=branchlist.split(",");
                    for(var t=0;t<branchlist;t++)
                    {
                        for(var n=1;n<document.getElementById('txtbranch').options.length;n++)
                        {
                            if(dsbranch.value.Tables[0].Rows[t].branchcode==document.getElementById('txtbranch').options[n].value)
                            {
                                document.getElementById('txtbranch').options[n].selected=true;
                            }
                            
                        }
                    }
                }

//                 document.getElementById('txtbranch').options[0].selected=false; 
//                  var branchlen=dsbranch.value.Tables[0].Rows.length;
//                  var flaglen=dsbranch.value.Tables[1].Rows.length;
//                  for(var t1=0;t1<document.getElementById('txtbranch').options.length;t1++)
//                 {
//                     document.getElementById('txtbranch').options[t1].selected=false;
//                 }
//                  for(var a1=0; a1<branchlen; a1++)
//                  {
//                     document.getElementById('txtbranch').options[a1].selected=false;
//                  }
//                  for(var a1=0; a1<branchlen; a1++)
//                  {
//                    for(var i=0; i<flaglen; i++)
//                    {
//                       if(dsbranch.value.Tables[0].Rows[a1].branchcode==dsbranch.value.Tables[1].Rows[i].branchcode)
//                       {
//                          document.getElementById('txtbranch').options[a1+1].selected=true; 
//                          i= flaglen;
//                       }
//                    }
//                 }
				//--------------------------------------------------------------------------//
				document.getElementById('txtCityCode').disabled=true;
				document.getElementById('txtCityName').disabled=true;
				document.getElementById('txtAlias').disabled=true;
				document.getElementById('drpDistrictName').disabled=true;
				document.getElementById('drpStateName').disabled=true;
				document.getElementById('drpZoneName').disabled=true;
				document.getElementById('drpCountryName').disabled=true;
				document.getElementById('txtCitySTD').disabled=true;
				document.getElementById('drpRegion').disabled=true;
				document.getElementById('txtbranch').disabled=true;
				updateStatus();
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
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
		}
		setButtonImages();
		if(document.getElementById('btnModify').disabled==false)
			document.getElementById('btnModify').focus();

return false;

		return false;
}


function Cityprevious()
{
  var msg=checkSession();
    if(msg==false)
    return false;
			var CityCode=document.getElementById('txtCityCode').value;
			var CityName=document.getElementById('txtCityName').value;
			var Alias=document.getElementById('txtAlias').value;
			var DistrictName=document.getElementById('drpDistrictName').value;
			var StateName=document.getElementById('drpStateName').value;
			var ZoneName=document.getElementById('drpZoneName').value;
			var CountryName=document.getElementById('drpCountryName').value;
			var CitySTD=document.getElementById('txtCitySTD').value;
			var Region=document.getElementById('drpRegion').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;

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
CityMaster.Selectfnpl(CityCode,CityName,Alias,DistrictName,StateName,ZoneName,CountryName,CitySTD,Region,compcode,userid,call_Previous);
			
			return false;
}

function call_Previous(response)
{
//var ds=response.value;
var a=dscityexecute.Tables[0].Rows.length;
z--;

    	if(z>a)
		{
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			return false;
		}
		if(z != -1  )
		{
		if(z >= 0 && z < a)
		{
			document.getElementById('txtCityCode').value=dscityexecute.Tables[0].Rows[z].City_Code;
			document.getElementById('txtCityName').value=dscityexecute.Tables[0].Rows[z].City_Name;
			document.getElementById('txtAlias').value=dscityexecute.Tables[0].Rows[z].City_Alias;
			
//			 statcode=dscityexecute.Tables[0].Rows[z].State_Code;
//			 distcode=dscityexecute.Tables[0].Rows[z].Dist_Code;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
				
			//CityMaster.distselect(compcode,userid,statcode,distcode,call_city); 
			
			document.getElementById('drpZoneName').value=dscityexecute.Tables[0].Rows[z].Zone_Code;
			fillregion();
			document.getElementById('drpCountryName').value=dscityexecute.Tables[0].Rows[z].Country_Code;
			document.getElementById('txtCitySTD').value=dscityexecute.Tables[0].Rows[z].STD_Code;
			document.getElementById('drpRegion').value=dscityexecute.Tables[0].Rows[z].Region_Code;
            fillcountry12();
            document.getElementById('drpStateName').value=dscityexecute.Tables[0].Rows[z].State_Code;
            binddist();
            document.getElementById('drpDistrictName').value=dscityexecute.Tables[0].Rows[z].Dist_Code;
              //-----------------------------------------------------------------------//
				 var dsbranch=CityMaster.branchexecute(compcode,dscityexecute.Tables[0].Rows[z].City_Code);
				 if(dsbranch.value==null)
				 {
				    return false;
				 }
				 var branchlist = dsbranch.value.Tables[0].Rows.length;	
                  for(var t=0;t<document.getElementById('txtbranch').options.length;t++)
                    {
                         document.getElementById('txtbranch').options[t].selected=false;
                    }
                if(branchlist!="" && branchlist!=null)
                {
                    //var data=branchlist.split(",");
                    for(var t=0;t<branchlist;t++)
                    {
                        for(var n=1;n<document.getElementById('txtbranch').options.length;n++)
                        {
                            if(dsbranch.value.Tables[0].Rows[t].branchcode==document.getElementById('txtbranch').options[n].value)
                            {
                                document.getElementById('txtbranch').options[n].selected=true;
                            }
                            
                        }
                    }
                }

//                  document.getElementById('txtbranch').options[0].selected=false; 
//                  var branchlen=dsbranch.value.Tables[0].Rows.length;
//                  var flaglen=dsbranch.value.Tables[1].Rows.length;
//                    for(var t1=0;t1<document.getElementById('txtbranch').options.length;t1++)
//                     {
//                         document.getElementById('txtbranch').options[t1].selected=false;
//                     }
//                  for(var a=0; a<branchlen; a++)
//                  {
//                     document.getElementById('txtbranch').options[a].selected=false;
//                  }
//                  for(var a=0; a<branchlen; a++)
//                  {
//                    for(var i=0; i<flaglen; i++)
//                    {
//                       if(dsbranch.value.Tables[0].Rows[a].branchcode==dsbranch.value.Tables[1].Rows[i].branchcode)
//                       {
//                          document.getElementById('txtbranch').options[a+1].selected=true; 
//                          i= flaglen;
//                       }
//                    }
//                 }
				//--------------------------------------------------------------------------//				
			document.getElementById('txtCityCode').disabled=true;
			document.getElementById('txtCityName').disabled=true;
			document.getElementById('txtAlias').disabled=true;
			document.getElementById('drpDistrictName').disabled=true;
			document.getElementById('drpStateName').disabled=true;
			document.getElementById('drpZoneName').disabled=true;
			document.getElementById('drpCountryName').disabled=true;
			document.getElementById('txtCitySTD').disabled=true;
			document.getElementById('drpRegion').disabled=true;
            document.getElementById('txtbranch').disabled=true;
            
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
		
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		setButtonImages();
		if(document.getElementById('btnModify').disabled==false)
			document.getElementById('btnModify').focus();
return false;
}

function Citylast()
{
 var msg=checkSession();
    if(msg==false)
    return false;
			var CityCode=document.getElementById('txtCityCode').value;
			var CityName=document.getElementById('txtCityName').value;
			var Alias=document.getElementById('txtAlias').value;
			var DistrictName=document.getElementById('drpDistrictName').value;
			var StateName=document.getElementById('drpStateName').value;
			var ZoneName=document.getElementById('drpZoneName').value;
			var CountryName=document.getElementById('drpCountryName').value;
			var CitySTD=document.getElementById('txtCitySTD').value;
			var Region=document.getElementById('drpRegion').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;

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
CityMaster.Selectfnpl(CityCode,CityName,Alias,DistrictName,StateName,ZoneName,CountryName,CitySTD,Region,compcode,userid,call_Last);
			
				
									
			updateStatus();
            document.getElementById('btnfirst').disabled=false;
		    document.getElementById('btnnext').disabled=true;
		    document.getElementById('btnlast').disabled=true;
		    document.getElementById('btnprevious').disabled=false;
		    if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
			
			return false;
}

function call_Last(response)
{
		//var ds=response.value;
		var y=dscityexecute.Tables[0].Rows.length;
		z=y-1;
		
		document.getElementById('txtCityCode').value=dscityexecute.Tables[0].Rows[z].City_Code;
		document.getElementById('txtCityName').value=dscityexecute.Tables[0].Rows[z].City_Name;
		document.getElementById('txtAlias').value=dscityexecute.Tables[0].Rows[z].City_Alias;
		
//		 statcode=dscityexecute.Tables[0].Rows[z].State_Code;
//		 distcode=dscityexecute.Tables[0].Rows[z].Dist_Code;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
				
				
		//CityMaster.distselect(compcode,userid,statcode,distcode,call_city); 
		
		document.getElementById('drpZoneName').value=dscityexecute.Tables[0].Rows[z].Zone_Code;
		fillregion();
		document.getElementById('drpCountryName').value=dscityexecute.Tables[0].Rows[z].Country_Code;
		document.getElementById('txtCitySTD').value=dscityexecute.Tables[0].Rows[z].STD_Code;
		document.getElementById('drpRegion').value=dscityexecute.Tables[0].Rows[z].Region_Code;
        fillcountry12();
        document.getElementById('drpStateName').value=dscityexecute.Tables[0].Rows[z].State_Code;
        binddist();
        document.getElementById('drpDistrictName').value=dscityexecute.Tables[0].Rows[z].Dist_Code;
            //-----------------------------------------------------------------------//
				 var dsbranch=CityMaster.branchexecute(compcode,dscityexecute.Tables[0].Rows[z].City_Code);
//				 if(dsbranch.value==null)
//				 {
//				    return false;
//				 }
//				 var branchlist = dsbranch.value.Tables[0].Rows.length;	
//                  for(var t=0;t<document.getElementById('txtbranch').options.length;t++)
//                    {
//                         document.getElementById('txtbranch').options[t].selected=false;
//                    }
//                if(branchlist!="" && branchlist!=null)
//                {
//                    //var data=branchlist.split(",");
//                    for(var t=0;t<branchlist;t++)
//                    {
//                        for(var n=1;n<document.getElementById('txtbranch').options.length;n++)
//                        {
//                            if(dsbranch.value.Tables[0].Rows[t].branchcode==document.getElementById('txtbranch').options[n].value)
//                            {
//                                document.getElementById('txtbranch').options[n].selected=true;
//                            }
//                            
//                        }
//                    }
//                }

                  document.getElementById('txtbranch').options[0].selected=false; 
                  var branchlen=dsbranch.value.Tables[0].Rows.length;
                  var flaglen=dsbranch.value.Tables[1].Rows.length;
                    for(var t1=0;t1<document.getElementById('txtbranch').options.length;t1++)
                 {
                     document.getElementById('txtbranch').options[t1].selected=false;
                 }
                  for(var a=0; a<branchlen; a++)
                  {
                     document.getElementById('txtbranch').options[a].selected=false;
                  }
                  for(var a=0; a<branchlen; a++)
                  {
                    for(var i=0; i<flaglen; i++)
                    {
                       if(dsbranch.value.Tables[0].Rows[a].branchcode==dsbranch.value.Tables[1].Rows[i].branchcode)
                       {
                          document.getElementById('txtbranch').options[a+1].selected=true; 
                          i= flaglen;
                       }
                    }
                 }
				//--------------------------------------------------------------------------//		
				
		document.getElementById('txtCityCode').disabled=true;
		document.getElementById('txtCityName').disabled=true;
		document.getElementById('txtAlias').disabled=true;
		document.getElementById('drpDistrictName').disabled=true;
		document.getElementById('drpStateName').disabled=true;
		document.getElementById('drpZoneName').disabled=true;
		document.getElementById('drpCountryName').disabled=true;
		document.getElementById('txtCitySTD').disabled=true;
		document.getElementById('drpRegion').disabled=true;
	    document.getElementById('txtbranch').disabled=true;
	    setButtonImages();
		return false;
}

function Cityexit()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.close();
			return false;
		}
		return false;

}

function Citydelete()
{
  var msg=checkSession();
    if(msg==false)
    return false;
			var CityCode=document.getElementById('txtCityCode').value;
			var CityName=document.getElementById('txtCityName').value;
			var Alias=document.getElementById('txtAlias').value;
			var DistrictName=document.getElementById('drpDistrictName').value;
			var StateName=document.getElementById('drpStateName').value;
			var ZoneName=document.getElementById('drpZoneName').value;
			var CountryName=document.getElementById('drpCountryName').value;
			var CitySTD=document.getElementById('txtCitySTD').value;
			var Region=document.getElementById('drpRegion').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			if(confirm("Are You Sure To Delete The Data"))
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
CityMaster.DeleteValue(CityCode,compcode,userid,ip2);
					//alert("Value Deleted Sucessfully");
					if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                    }
                    else
                    {
	                    alert(xmlObj.childNodes(0).childNodes(2).text);
	                }
			
					CityMaster.select(compcode, gbcitycode, gbcityname, gbalias, gbdistrict, gbstatename, gbzonename, gbcountry, gbcitystd, gbregion, userid, call_deleteclick);
		
					//CityMaster.Selectfnpl(CityCode,CityName,Alias,DistrictName,StateName,ZoneName,CountryName,CitySTD,Region,compcode,userid,call_deleteclick);
			}
			else
			{
			    return false;
			}
			//chkstatus(FlagStatus);
			updateStatus();
			return false;
}

function call_deleteclick(response)
{
	dscityexecute= response.value;
	len=dscityexecute.Tables[0].Rows.length;
	if(dscityexecute.Tables[0].Rows.length==0)
	{
			alert("There Is No Data");
			document.getElementById('txtCityCode').value="";
			document.getElementById('txtCityName').value="";
			document.getElementById('txtAlias').value="";
			document.getElementById('drpDistrictName').value="0";
			document.getElementById('drpStateName').value="0";
			document.getElementById('drpZoneName').value="0";
			document.getElementById('drpCountryName').value="0";
			document.getElementById('txtCitySTD').value="";
			document.getElementById('drpRegion').value="0";
			Citycancel('CityMaster');
			return false;
	}
	else if(z==-1 ||z>=len)
	{
//			 statcode=dscityexecute.Tables[0].Rows[0].State_Code;
//			 distcode=dscityexecute.Tables[0].Rows[0].Dist_Code;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
				fillcountry12();
				
			//CityMaster.distselect(compcode,userid,statcode,distcode,call_city);
			
			document.getElementById('txtCityCode').value=dscityexecute.Tables[0].Rows[0].City_Code;
			document.getElementById('txtCityName').value=dscityexecute.Tables[0].Rows[0].City_Name;
			document.getElementById('txtAlias').value=dscityexecute.Tables[0].Rows[0].City_Alias;
			//document.getElementById('drpDistrictName').value=ds.Tables[0].Rows[0].Dist_Code;
			//document.getElementById('drpStateName').value=ds.Tables[0].Rows[0].State_Code;
			document.getElementById('drpZoneName').value=dscityexecute.Tables[0].Rows[0].Zone_Code;
			document.getElementById('drpCountryName').value=dscityexecute.Tables[0].Rows[0].Country_Code;
			document.getElementById('txtCitySTD').value=dscityexecute.Tables[0].Rows[0].STD_Code;
			document.getElementById('drpRegion').value=dscityexecute.Tables[0].Rows[0].Region_Code;
			document.getElementById('drpStateName').value=dscityexecute.Tables[0].Rows[0].State_Code;
            binddist();
            document.getElementById('drpDistrictName').value=dscityexecute.Tables[0].Rows[0].Dist_Code;
	}
	else
	{
//			 statcode=dscityexecute.Tables[0].Rows[z].State_Code;
//			 distcode=dscityexecute.Tables[0].Rows[z].Dist_Code;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
				
				
			//CityMaster.distselect(compcode,userid,statcode,distcode,call_city);
			
			document.getElementById('txtCityCode').value=dscityexecute.Tables[0].Rows[z].City_Code;
			document.getElementById('txtCityName').value=dscityexecute.Tables[0].Rows[z].City_Name;
			document.getElementById('txtAlias').value=dscityexecute.Tables[0].Rows[z].City_Alias;
			//document.getElementById('drpDistrictName').value=ds.Tables[0].Rows[z].Dist_Code;
			//document.getElementById('drpStateName').value=ds.Tables[0].Rows[z].State_Code;
			document.getElementById('drpZoneName').value=dscityexecute.Tables[0].Rows[z].Zone_Code;
			document.getElementById('drpCountryName').value=dscityexecute.Tables[0].Rows[z].Country_Code;
			document.getElementById('txtCitySTD').value=dscityexecute.Tables[0].Rows[z].STD_Code;
			document.getElementById('drpRegion').value=dscityexecute.Tables[0].Rows[z].Region_Code;
			fillcountry12();
			document.getElementById('drpStateName').value=dscityexecute.Tables[0].Rows[0].State_Code;
            binddist();
            document.getElementById('drpDistrictName').value=dscityexecute.Tables[0].Rows[0].Dist_Code;
	}
	setButtonImages();
	return false;
}


       
        
 function autoornot()
 {
 //if(hiddentext=="new" )
 //{
////      if (document.getElementById('drpCountryName').value=="0")
////	    {
////	        if(hiddentext=="new" )
////	        {
////			    alert("Please Select Country Name");
////			    document.getElementById('drpCountryName').focus();
////			    return false;
////	        }
////	        else
////	        {
////	        return false;
////	        }
////	    }
    if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
   // return false;
    }
else
    {
    userdefine();

    //return false;
//return false;
    }
}
//}
// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new")
			{
	
            //uppercase3();
            document.getElementById('txtCityName').value=trim(document.getElementById('txtCityName').value);
              lstr=document.getElementById('txtCityName').value;
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
	
	
            
		    if(document.getElementById('txtCityName').value!="")
                {
                 
		        document.getElementById('txtCityName').value=document.getElementById('txtCityName').value.toUpperCase();
	            document.getElementById('txtAlias').value=document.getElementById('txtCityName').value;
		       // str=document.getElementById('txtCityName').value;
		       str=mstr;
		        CityMaster.chkcode(str,document.getElementById('drpCountryName').value,fillcall);
		        //return false;
                }
        
		       
            
 return false;
		
//}
           
           }
       else
            {
            document.getElementById('txtCityName').value=document.getElementById('txtCityName').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

/*function uppercase3()
		{
		    document.getElementById('txtCityName').value=trim(document.getElementById('txtCityName').value);
              lstr=document.getElementById('txtCityName').value;
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
	
	
            
		    if(document.getElementById('txtCityName').value!="")
                {
                 
		        document.getElementById('txtCityName').value=document.getElementById('txtCityName').value.toUpperCase();
	            document.getElementById('txtAlias').value=document.getElementById('txtCityName').value;
		       // str=document.getElementById('txtCityName').value;
		       str=mstr;
		        CityMaster.chkcode(str,fillcall);
		        //return false;
                }
        
		       
            
 return false;
		
}*/

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This City name has already assigned !! ");
		    document.getElementById('txtCityName').value="";
            document.getElementById('txtCityCode').value="";
            document.getElementById('txtAlias').value="";
            document.getElementById('txtCityName').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].City_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        code++;
		                        str=str.toUpperCase();
		                        document.getElementById('txtCityCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtCityCode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtCityCode').disabled=false;
        document.getElementById('txtCityName').value=document.getElementById('txtCityName').value.toUpperCase();
        document.getElementById('txtAlias').value=document.getElementById('txtCityName').value;
        auto=document.getElementById('hiddenauto').value;
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

/*new change ankur 10 feb*/
function enabledist()
{
        if(document.getElementById('hiddenHindustan').value=="Hindustan")
        {
            //document.getElementById('district').style.display="none";
            //document.getElementById('zone').style.display="none";
            //document.getElementById('region').style.display="none";
        
        }
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